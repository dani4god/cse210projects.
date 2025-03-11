using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        bool running = true;
        while (running)
        {
Console.WriteLine("\n Journal menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the Journal");
            Console.WriteLine("3. Save the Journal to a file");
            Console.WriteLine("4. load the journal from a file.");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Choose an option");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": 
                    journal.AddEntry();
                    break;
                case "2": 
                    journal.DisplayEntries();
                    break;
                case "3": 
                    journal.SaveToFile();
                    break;
                case "4": 
                    journal.LoadFromFile();
                    break;
                case "5": 
                    running = false;
Console.WriteLine("Invalid option, pleae try again. \n");    
                break;
            }


        }
    }
}
class Entry
    {
        public string Date{ get; set;}
        public string Prompt{ get; set;}
        public string Response{ get; set;}
        public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
    }
    public override string ToString()
        {
            return $"{Date}- {Prompt}\n{Response}\n";
        }
    
}
class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts  = new List<string>
    {
        "Who was the most interesting person I interracted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my Life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    private Random random = new Random();
    
    public void AddEntry()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"\nprompt: {prompt}");
        Console.WriteLine("Your response: ");
        string response = Console.ReadLine();

        entries.Add(new Entry(prompt, response));
        Console.WriteLine("Entry saved");

    }
    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
        }

        else
        {
            foreach (Entry entry in entries)
            {
Console.WriteLine(entry);
            }
        }  
        
    }
    public void SaveToFile()
    {
        Console.Write("Enter filename to save (e.g., journal.json)");
        string filename = Console.ReadLine();
        string json = JsonSerializer.Serialize(DisplayEntries, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved successfully");
    }
    public void LoadFromFile()
    {
        Console.Write("Enter filename to load (e.g., journal.json;) ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            entries = JsonSerializer.Deserialize<List<Entry>>(json);
            Console.WriteLine("Journal loaded successfully");  
        }
        else
        {
        Console.WriteLine("File not found");
        }
    }

} 
 

    