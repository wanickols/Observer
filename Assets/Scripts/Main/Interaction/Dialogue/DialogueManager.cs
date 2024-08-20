using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private TextMeshProUGUI hintBox;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI text;

    private string[] lines;
    public float textSpeed;

    private int index;

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

    private void Start()
    {
        text.text = string.Empty;
    }

    public void StartMessage(string[] messages)
    {
        index = 0;
        StopAllCoroutines();
        text.text = string.Empty;
        lines = messages;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeLine());
    }


    public void DialogueInteract()
    {
        if (lines == null)
            return;

        if (text.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            text.text = lines[index];
        }
    }

    public void DisplayHint(string text)
    {
        hintBox.text = text;
        hintBox.gameObject.SetActive(true);
    }


    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            ++index;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            HideMessage();
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void DisplayMessage(string message)
    {
        text.text = message;
        dialogueBox.SetActive(true);
    }

    public void HideMessage()
    {
        text.text = string.Empty;
        dialogueBox.SetActive(false);
        hintBox.gameObject.SetActive(false);
    }
}
