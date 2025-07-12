// Journal.cs
using System;
using System.Collections.Generic; 
using System.IO;                  

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty. Write an entry first!");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("--- End of Journal ---");
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
                }
            }
            Console.WriteLine($"Journal saved to {filename} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }
    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        try
        {
            using (StreamReader inputFile = new StreamReader(filename))
            {
                string line;
                while ((line = inputFile.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');

                    if (parts.Length == 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string entryText = parts[2];

                        Entry newEntry = new Entry(prompt, entryText, date);
                        _entries.Add(newEntry);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Skipping malformed line in file: {line}");
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {filename} successfully. Total entries: {_entries.Count}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File '{filename}' not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}