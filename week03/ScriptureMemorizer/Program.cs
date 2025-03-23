using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "scripture.txt";

        // Hardcoded scriptures
        List<string> scriptures = new List<string>
        {
            "John 3:16 - For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.",
            "Proverbs 3:5-6 - Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.",
            "Philippians 4:13 - I can do all things through Christ which strengtheneth me.",
            "Psalm 23:1 - The Lord is my shepherd; I shall not want."
        };

        // Write scriptures to the file if it doesn't exist
        if (!File.Exists(filePath))
        {
            File.WriteAllLines(filePath, scriptures);
        }

        // Load scriptures from file
        List<string> loadedScriptures = new List<string>(File.ReadAllLines(filePath));
        Random random = new Random();
        string selectedScripture = loadedScriptures[random.Next(loadedScriptures.Count)];

        // Display difficulty options
        Console.WriteLine("Choose a difficulty level:");
        Console.WriteLine("1. Easy (1 word at a time)");
        Console.WriteLine("2. Medium (3 words at a time)");
        Console.WriteLine("3. Hard (5 words at a time)");
        int difficulty = int.Parse(Console.ReadLine() ?? "2");

        int wordsToHide = difficulty switch
        {
            1 => 1,
            2 => 3,
            3 => 5,
            _ => 3
        };

        Scripture scripture = new Scripture(selectedScripture);
        Console.Clear();

        // Start memorization process
        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine(scripture.GetFormattedScripture());
            Console.WriteLine("\nPress Enter to hide words, type 'hint' to reveal one word, or 'quit' to exit.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
            {
                Console.WriteLine("\nThank you for using the Scripture Memorizer!");
                break;
            }
            else if (input == "hint")
            {
                scripture.RevealWord();
            }
            else
            {
                scripture.HideWords(wordsToHide);
            }

            Console.Clear();
        }

        // Final display
        Console.WriteLine(scripture.GetFormattedScripture());
        Console.WriteLine("\nWell done! You've memorized the scripture.");
    }
}

// Scripture class manages the scripture text and hiding words
class Scripture
{
    private string _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(string fullText)
    {
        int dashIndex = fullText.IndexOf(" - ");
        if (dashIndex > 0)
        {
            _reference = fullText.Substring(0, dashIndex);
            string text = fullText.Substring(dashIndex + 3);
            _words = text.Split(' ').Select(word => new Word(word)).ToList();
        }
        else
        {
            _reference = "Unknown Reference";
            _words = fullText.Split(' ').Select(word => new Word(word)).ToList();
        }
    }

    public void HideWords(int count)
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public void RevealWord()
    {
        List<Word> hiddenWords = _words.Where(w => w.IsHidden()).ToList();
        if (hiddenWords.Count > 0)
        {
            int index = _random.Next(hiddenWords.Count);
            hiddenWords[index].Reveal();
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetFormattedScripture()
    {
        return $"{_reference} - {string.Join(" ", _words.Select(w => w.GetDisplayWord()))}";
    }
}

// Word class manages individual words in the scripture
class Word
{
    private string _originalWord;
    private bool _hidden;

    public Word(string word)
    {
        _originalWord = word;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public void Reveal()
    {
        _hidden = false;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public string GetDisplayWord()
    {
        return _hidden ? new string('_', _originalWord.Length) : _originalWord;
    }
}
 


