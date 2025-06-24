using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : Singleton<LoadManager>
{
    private Coroutine _transitionCoroutine;

    private AsyncOperation LoadScene(SceneType sceneType)
    {
        return SceneManager.LoadSceneAsync($"{sceneType.ToString()}Scene");
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

    public void ChangeScene(SceneType sceneType)
    {
        if (_transitionCoroutine != null) StopCoroutine(_transitionCoroutine);
        _transitionCoroutine = StartCoroutine(TransitionCoroutine(sceneType));
    }

    private IEnumerator TransitionCoroutine(SceneType sceneType)
    {
        var loadScene = LoadScene(sceneType);
        loadScene.allowSceneActivation = false;
        while (!loadScene.isDone)
        {
            if (loadScene.progress >= 0.9f)
            {
                loadScene.allowSceneActivation = true;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

        EventManager.OnSceneChanged?.Invoke(sceneType);
    }
}
