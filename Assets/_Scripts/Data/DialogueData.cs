using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/DialogueData", order = 1)]
public class DialogueData : ScriptableObject
{
    public List<DialogueConfig> dialogueList;

    public DialogueConfig GetRandomDialogue()
    {
        if (dialogueList == null || dialogueList.Count == 0) return null;

        int randomIndex = UnityEngine.Random.Range(0, dialogueList.Count);
        return dialogueList[randomIndex];
    }
}

[Serializable]
public class DialogueConfig
{
    [TextArea] public string description;
}
