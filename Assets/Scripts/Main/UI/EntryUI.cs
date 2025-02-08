using TMPro;
using UnityEngine;

public class EntryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI LevelVal;
    [SerializeField] private TextMeshProUGUI IDVal;
    [SerializeField] private TextMeshProUGUI Description;

    public void setAll(JournalEntry entry)
    {
        Title.text = entry.title;
        LevelVal.text = entry.levelID.ToString();
        IDVal.text = entry.journalID.ToString();
        Description.text = entry.description;
    }
}
