using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public DialogueData dialogueData { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (!dialogueData) dialogueData = LoadManager.SODataLoad<DialogueData>("DialogueData");
    }

}
