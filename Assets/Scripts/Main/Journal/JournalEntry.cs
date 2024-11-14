using UnityEngine;

[CreateAssetMenu(fileName = "New Journal Entry", menuName = "Journal/Entry")]
public class JournalEntry : ScriptableObject
{
    public int levelID;
    public int journalID;
    public string title;
    public string description;

    // Override the == operator to compare JournalEntry objects
    public static bool operator ==(JournalEntry entry1, JournalEntry entry2)
    {
        // Check for null and if both are the same instance
        if (ReferenceEquals(entry1, entry2)) return true;

        // If one is null and the other isn't, return false
        if (ReferenceEquals(entry1, null) || ReferenceEquals(entry2, null)) return false;

        // Compare levelID and journalID to check equality
        return entry1.levelID == entry2.levelID && entry1.journalID == entry2.journalID;
    }

    // Override the != operator as well
    public static bool operator !=(JournalEntry entry1, JournalEntry entry2)
    {
        return !(entry1 == entry2); // Simply use the != as the inverse of ==
    }

    // Override Equals method
    public override bool Equals(object obj)
    {
        // Return false if the object is not a JournalEntry
        if (obj == null || GetType() != obj.GetType()) return false;

        JournalEntry other = (JournalEntry)obj;
        return this == other; // Uses the == operator
    }
}
