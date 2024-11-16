using UnityEngine;
public class JournalCommand : Command
{
    [SerializeField] JournalEntry journalEntry;
    public override void Perform() => Journal.Instance.AddEntry(journalEntry);
}
