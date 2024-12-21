using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public TextMeshProUGUI nameText, dialogueText;
    public Image character1, character2;

    private Queue<DialogueLine> lines;
    // Start is called before the first frame update
    void Start()
    {
        Instance ??= this;
        lines = new();
    }

    public void StartDialogue(Dialogues dialogue)
    {
        // logic untuk menampilkan dialognya: animasi munculnya mau gimana?
        lines.Clear();
        foreach(DialogueLine line in dialogue.dialogueLines)
        {
            lines.Enqueue(line);
        }
    }

    void DisplayDialogue()
    {
        if(lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();
        character1.sprite = currentLine.dialogueCharacter.character1;
        nameText.text = currentLine.dialogueCharacter.characterName;
        if(currentLine.dialogueCharacter.character2 != null)
        {
            character2.sprite = currentLine.dialogueCharacter.character2;
            character2.gameObject.SetActive(true);
            if(currentLine.dialogueCharacter.isCharacter1)
            {
                character2.color = Color.gray;
                character1.color = Color.white;
            }
            else
            {
                character2.color = Color.white;
                character1.color = Color.gray;
            }
        }
        else
        {
            character2.gameObject.SetActive(false);
        }

        StopAllCoroutines();
        StartCoroutine(TypeDialogue(currentLine));
    }

    public void EndDialogue()
    {
        // hilangkan dialog
    }

    private IEnumerator TypeDialogue(DialogueLine line)
    {
        dialogueText.text = String.Empty;
        foreach(char letter in line.line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    } 
}
