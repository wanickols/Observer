using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public static Journal Instance { get; private set; } // Singleton instance

    private List<JournalEntry> entries; // Main list of entries
    public List<JournalEntry> displayEntries { get; private set; } // Separate list for display purposes

    private void Awake()
    {
        // Singleton pattern: Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate instances
            return; // Exit to avoid reinitializing
        }

        // Initialize the entry lists
        entries = new List<JournalEntry>();
        displayEntries = new List<JournalEntry>();
    }
    public bool AddEntry(JournalEntry entry)
    {
        if (entries.Contains(entry)) // Uses the == operator
            return false;

        entries.Add(entry);
        return true;
    }

    public bool RemoveEntry(JournalEntry entry)
    {
        if (!entries.Contains(entry))
            return false;

        entries.Remove(entry);
        return true;
    }

    //Returns list of entries for display use
    public List<JournalEntry> display(int levelID)
    {

        if (levelID < 0)
        {
            displayEntries = entries;
            return displayEntries;
        }

        displayEntries.Clear();
        foreach (JournalEntry entry in entries)
        {
            if (levelID == entry.levelID)
                displayEntries.Add(entry);
        }

        return displayEntries;
    }

}
