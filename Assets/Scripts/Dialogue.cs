using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;


    private float readDelay = 1.2f;
    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private bool hasDialogueFinished;
    private bool isLineFullyDisplayed;


    private void Update()
    {
        if (isPlayerInRange && !hasDialogueFinished)
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (isLineFullyDisplayed)
            {
                NextDialogueLine();
            }
        }
    }

    private IEnumerator ShowLine()
    {
        isLineFullyDisplayed = false;
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }

        yield return new WaitForSecondsRealtime(readDelay); 
        isLineFullyDisplayed = true;
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            hasDialogueFinished = true; 
            dialoguePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
}
