using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DisplayMessage(string message)
    {
        text.text = message;
        dialogueBox.SetActive(true);
    }

    public void HideMessage()
    {
        text.text = "";
        dialogueBox.SetActive(false);
    }
}
