using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Button _sceneTransitionButton;
    public DialoguePanel DialoguePanel { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if(!DialoguePanel) DialoguePanel = GetComponentInChildren<DialoguePanel>();
        _sceneTransitionButton.onClick.AddListener(OnSceneTransitionButtonClicked);
    }

    private void OnSceneTransitionButtonClicked()
    {
        LoadManager.LoadScene("Huting");
    }
}
