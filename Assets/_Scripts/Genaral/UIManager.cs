using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Button _sceneTransitionButton;

    protected override void Awake()
    {
        base.Awake();
        _sceneTransitionButton.onClick.AddListener(OnSceneTransitionButtonClicked);
    }

    private void OnSceneTransitionButtonClicked()
    {
        LoadManager.LoadScene("Huting");
    }
}
