using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!\n");
        Scripture scripture = Scripture.LoadOrGetNew();
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
    Console.WriteLine(scripture.GetDisplayText());
    Console.WriteLine($"$\nWords Remaining: {scripture.WordsRemaining()}");
            
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to save & exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
    scripture.SaveProgress();
    Console.WriteLine("Progress saved. Goodbye!");
                return;
            }
    scripture.HideRandomWords(3);
        }
        Console.Clear();
Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\n Congratulations! You've memorized thescripture!");
File.Delete("progress.json"); // Clear saved progress after completion
    }
}
// Stores scripture reference (e.g., "John 3:16")
class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; } // Nullable for single-verse references
    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {

        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }
    public string GetDisplayText()
    {
        return EndVerse.HasValue ? $"${Book} {Chapter}:{StartVerse}-{EndVerse}" : $"{Book} {Chapter}:{StartVerse}";
    }
}
//  Represents a single word in the scripture
class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }
    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
    public void Hide() => IsHidden = true;
    public string GetDisplayText() => IsHidden ? new string('_', Text.Length): Text;
}
// Stores scripture text and handles word hiding
class Scripture
{
    public Reference ScriptureReference { get; }
    private List<Word> Words { get; }
    public Scripture(Reference reference, string text)
    {
        ScriptureReference = reference;
        Words = text.Split("").Select(word => new Word(word)).ToList();
    }
    public string GetDisplayText()
    {
        string wordsText = string.Join("", Words.Select(w => w.GetDisplayText()));
        return $"{ScriptureReference.GetDisplayText()} - {wordsText}";
    }
    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<Word> visibleWords = Words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count == 0) return; // All words are already hidden

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Remove to prevent re-hiding
        }
    }
    public bool IsCompletelyHidden() => Words.All(w => w.IsHidden);
    public int WordsRemaining() => Words.Count(w => !w.IsHidden); //  Save progress to a file
    public void SaveProgress()
    {
        var data = new { Reference = ScriptureReference.GetDisplayText(),
        Words = Words.Select(w => new { w.Text, w.IsHidden }).ToList() };
        File.WriteAllText("progress.json", JsonSerializer.Serialize(data, new
        JsonSerializerOptions { WriteIndented = true }));
    }

// �� Load progress or pick a new scripture
    public static Scripture LoadOrGetNew()
    {
        if (File.Exists("progress.json"))
        {
            string json = File.ReadAllText("progress.json");
            var data = JsonSerializer.Deserialize<Dictionary<string,object>>(json);
            string referenceText = data["Reference"].ToString();
            var wordsData = JsonSerializer.Deserialize<List<Dictionary<string,object>>>(data["Words"].ToString());
        // Extract reference details
            string[] parts = referenceText.Split(new[] {  ':' }, StringSplitOptions.RemoveEmptyEntries);Reference reference = new Reference(parts[0],
            int.Parse(parts[1]), int.Parse(parts[2]), parts.Length > 3 ? int.Parse(parts[3]) : (int?)null);
// Reconstruct words list
            Scripture scripture = new Scripture(reference, string.Join("",
            wordsData.Select(w => w["Text"].ToString())));
            for (int i = 0; i < wordsData.Count; i++)
            {
                if ((bool)wordsData[i]["IsHidden"])
                scripture.Words[i].Hide();
            }
            return scripture;
        }
// If no saved progress, pick a new scripture
        return GetRandomScripture();
    }

// Pick a random scripture from a list
    private static Scripture GetRandomScripture()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
new Scripture(new Reference("Romans", 8, 28), "And we know that all things work together for good to them that love God, to them who are thecalled according to his purpose.")
        };
        Random random = new Random();
        return scriptures[random.Next(scriptures.Count)];
    }
}