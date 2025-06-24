using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public TownUI TownPanel { get; private set; }
    public HuntingUI HuntingPanel { get; private set; }
    public DialoguePanel DialoguePanel { get; private set; }
    public ShopPanel ShopPanel { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if(!DialoguePanel) DialoguePanel = GetComponentInChildren<DialoguePanel>();
        if(!TownPanel) TownPanel = GetComponentInChildren<TownUI>();
        if(!HuntingPanel) HuntingPanel = GetComponentInChildren<HuntingUI>();
        if(!ShopPanel) ShopPanel = GetComponentInChildren<ShopPanel>();
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
        TownPanel.gameObject.SetActive(sceneType == SceneType.Town);
        HuntingPanel.gameObject.SetActive(sceneType == SceneType.Hunting);
        
        DialoguePanel.PanelState(false);
        ShopPanel.PanelState(false);
    }

}
