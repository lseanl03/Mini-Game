using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public DialoguePanel DialoguePanel { get; private set; }
    public TownPanel TownPanel { get; private set; }
    public HuntingPanel HuntingPanel { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if(!DialoguePanel) DialoguePanel = GetComponentInChildren<DialoguePanel>();
        if(!TownPanel) TownPanel = GetComponentInChildren<TownPanel>();
        if(!HuntingPanel) HuntingPanel = GetComponentInChildren<HuntingPanel>();
    }
    private void OnEnable()
    {
        EventManager.OnSceneChanged += OnSceneChanged;
    }
    private void OnDisable()
    {
        EventManager.OnSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(SceneType sceneType)
    {
        TownPanel.PanelState(sceneType == SceneType.Town);
        HuntingPanel.PanelState(sceneType == SceneType.Hunting);
        DialoguePanel.PanelState(false);
    }

}
