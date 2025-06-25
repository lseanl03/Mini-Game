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
    public InventoryPanel InventoryPanel { get; private set; }
    public SelectingShopItemPanel SelectingShopItemPanel { get; private set; }
    public SelectingInventoryItemPanel SelectingInventoryItemPanel { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        if(!TownPanel) TownPanel = GetComponentInChildren<TownUI>();
        if(!ShopPanel) ShopPanel = GetComponentInChildren<ShopPanel>();
        if(!HuntingPanel) HuntingPanel = GetComponentInChildren<HuntingUI>();
        if (!DialoguePanel) DialoguePanel = GetComponentInChildren<DialoguePanel>();
        if (!InventoryPanel) InventoryPanel = GetComponentInChildren<InventoryPanel>();
        if(!SelectingShopItemPanel) SelectingShopItemPanel = GetComponentInChildren<SelectingShopItemPanel>();
        if(!SelectingInventoryItemPanel) SelectingInventoryItemPanel = GetComponentInChildren<SelectingInventoryItemPanel>();
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
