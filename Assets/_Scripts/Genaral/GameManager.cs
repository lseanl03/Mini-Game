using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int EnemyKilled { get; set; }
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] public SceneType SceneType;
    [SerializeField] float _spawnTime = 2f;
    public DialogueData dialogueData { get; private set; }
    private Coroutine spawnCoroutine;
    protected override void Awake()
    {
        base.Awake();
        if (!dialogueData) dialogueData = LoadManager.SODataLoad<DialogueData>("DialogueData");
    }

    private void OnEnable()
    {
        EventManager.OnSceneChanged += OnSceneChanged;
    }

    private void OnDisable()
    {
        EventManager.OnSceneChanged -= OnSceneChanged;
    }

    private void Start()
    {
        SceneType = SceneType.Town;
        UIManager.Instance.TownPanel.gameObject.SetActive(true);
    }

    private void OnSceneChanged(SceneType sceneType)
    {
        SceneType = sceneType;
        if (sceneType == SceneType.Town)
        {

        }
        else if (sceneType == SceneType.Hunting)
        {
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        if (spawnCoroutine != null) StopCoroutine(spawnCoroutine);
        spawnCoroutine = StartCoroutine(SpawnEnemyCoroutine());
    }
    private IEnumerator SpawnEnemyCoroutine()
    {
        while (SceneType == SceneType.Hunting)
        {
            var poolType = PoolType.Enemy_Slime;
            var enemy = PoolManager.Instance.GetObject<Enemy>(poolType, _spawnPoint.position, null);
            enemy.GetData(_spawnPoint, poolType);

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
