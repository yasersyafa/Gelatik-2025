using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptable Object/Dialogues")]
public class Dialogue : ScriptableObject
{
    public List<DialogueLine> dialogueLines = new();
}
