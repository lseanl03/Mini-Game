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
}
