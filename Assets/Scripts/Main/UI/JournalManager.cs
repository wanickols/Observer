using System.Collections.Generic;
using UnityEngine;

//UI Handler For Journal
public class JournalManager : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject contentHolder;
    [SerializeField] private GameObject entryPrefab;

    private List<JournalEntry> entries;
    private int level = -1;


    public void toggle(int level = -1)
    {
        canvas.enabled = !canvas.enabled;

        if (canvas.enabled)
            activate(level);

    }

    public void refresh() => displayEntries(level);

    private void activate(int level)
    {
        this.level = level;
        displayEntries(level);
    }
    private void displayEntries(int level)
    {
        // Clear existing children in contentHolder
        foreach (Transform child in contentHolder.transform)
            Destroy(child.gameObject);

        // Get the latest entries from the Journal
        entries = Journal.Instance.display(level);

        // Populate the contentHolder with new entries
        foreach (JournalEntry entry in entries)
        {
            EntryUI obj = Instantiate(entryPrefab, contentHolder.transform).GetComponent<EntryUI>();
            obj.setAll(entry);
        }
    }
}
