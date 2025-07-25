using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool
{
    public PoolType poolType;
    [SerializeField] private int initialSize;
    [SerializeField] private GameObject prefabObj;

    private GameObject parent;
    private List<GameObject> objList = new List<GameObject>();

    public void Initialize(GameObject parent)
    {
        if (!prefabObj) return;

        this.parent = parent;
        for (int i = 0; i < initialSize; i++)
        {
            CreateNewObject();
        }
    }

    public GameObject CreateNewObject()
    {
        GameObject obj = GameObject.Instantiate(prefabObj, parent.transform);
        obj.SetActive(false);
        objList.Add(obj);
        return obj;
    }

    public GameObject GetObject()
    {
        GameObject obj = objList.Find(o => !o.activeSelf);
        if (!obj)
        {
            obj = CreateNewObject();
        }
        obj.SetActive(true);
        return obj;
    }

    public void ReturnObject(GameObject obj, GameObject parent)
    {
        if (!objList.Contains(obj))
        {
            objList.Add(obj);
        }
        obj.SetActive(false);
        obj.transform.SetParent(parent.transform);
    }
}

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] private Pool[] pools;
    private Dictionary<PoolType, Pool> _poolDic = new Dictionary<PoolType, Pool>();
    private Dictionary<PoolType, GameObject> _parentDic = new Dictionary<PoolType, GameObject>();

    protected override void Awake()
    {
        base.Awake();
        InitializePools();
    }

    private void InitializePools()
    {
        foreach (Pool pool in pools)
        {
            GameObject poolParent = new GameObject($"{pool.poolType}_Pool");
            poolParent.transform.SetParent(transform);

            _parentDic[pool.poolType] = poolParent;
            _poolDic[pool.poolType] = pool;

            pool.Initialize(_parentDic[pool.poolType]);
        }
    }

    public T GetObject<T>(PoolType type, Vector3 position, Transform parent) where T : Component
    {
        if (!_poolDic.TryGetValue(type, out Pool pool))
        {
            return null;
        }

        GameObject obj = pool.GetObject();
        if (obj)
        {
            obj.transform.SetParent(parent);
            obj.transform.position = position;
            obj.transform.localScale = Vector3.one;
            return obj.GetComponent<T>();
        }
        return null;
    }

    public void ReturnObject(PoolType type, GameObject obj)
    {
        if (!obj) return;
        _poolDic[type].ReturnObject(obj, _parentDic[type]);
    }
}