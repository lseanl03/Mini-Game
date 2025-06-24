using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] float _spawnTime = 2f;
    
    public SceneType SceneType;
    public int EnemyKilled { get; set; }
    public DialogueData DialogueData { get; private set; }
    public ItemData ItemData { get; private set; }

    private Coroutine spawnCoroutine;
    protected override void Awake()
    {
        base.Awake();
        if (!DialogueData) DialogueData = LoadManager.SODataLoad<DialogueData>("DialogueData");
        if (!ItemData) ItemData = LoadManager.SODataLoad<ItemData>("ItemData");
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
        InitData();
    }

    private void InitData()
    {
        var content = UIManager.Instance.ShopPanel.Content;
        foreach (var item in ItemData.items)
        {
            ShopItem shopItem = PoolManager.Instance.GetObject<ShopItem>(
                PoolType.ShopItem, Vector2.zero, content);
            shopItem.Init(item);
        }
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
