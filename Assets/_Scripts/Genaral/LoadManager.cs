using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : Singleton<LoadManager>
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene($"{sceneName}Scene");
    }

    public static Sprite SpriteLoad(string path)
    {
        var spritePath = $"Sprites/{path}";
        Sprite sprite = Resources.Load<Sprite>(spritePath);
        if (sprite == null)
        {
            Debug.LogError($"Sprite not found at path: {spritePath}");
        }
        return sprite;
    }
    public static T PrefabLoad<T>(string path) where T : Component
    {
        var prefabPath = $"Prefabs/{path}";
        T prefab = Resources.Load<T>(prefabPath);
        if (prefab == null)
        {
            Debug.LogError($"Prefab not found at path: {prefabPath}");
        }
        return prefab;
    }

    public static T SODataLoad<T>(string path) where T : Object
    {
        var dataPath = $"SODatas/{path}";
        T data = Resources.Load<T>(dataPath);
        if (data == null)
        {
            Debug.LogError($"Data not found at path: {dataPath}");
        }
        return data;
    }
}
