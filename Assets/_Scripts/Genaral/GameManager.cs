using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Transform spawnPoint;
    public DialogueData dialogueData { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (!dialogueData) dialogueData = LoadManager.SODataLoad<DialogueData>("DialogueData");
    }

    private void Start()
    {
        var enemy = PoolManager.Instance.GetObject<Enemy>(PoolType.Enemy_Slime, spawnPoint.position, transform);
        enemy.PatrolPos = spawnPoint;
    }
}
