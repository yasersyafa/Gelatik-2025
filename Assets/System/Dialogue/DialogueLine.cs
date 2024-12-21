using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter dialogueCharacter;
    [TextArea(3, 10)] public string line;
}
