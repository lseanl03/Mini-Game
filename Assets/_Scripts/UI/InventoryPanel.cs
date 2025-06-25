using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : PanelBase
{
    [SerializeField] private Button _closeButton;
    [SerializeField] public RectTransform Content;

    protected override void Awake()
    {
        _hidePos = 350;
        _showPos = -300;
        _closeButton.onClick.AddListener(OnCloseClick);
        base.Awake();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.OnBuyShopItem += OnBuyShopItem;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.OnBuyShopItem -= OnBuyShopItem;

    }

    private void OnBuyShopItem(ItemConfig itemConfig)
    {
        var inventoryItem = PoolManager.Instance.GetObject<InventoryItem>(
                PoolType.InventoryItem, Vector2.zero, Content);
        inventoryItem.Init(itemConfig); 
    }
    protected override void OnCloseClick()
    {
        HidePanel();
        _uiManager.InventoryPanel.PanelState(false);
    }
    protected override void ShowPanel()
    {
        _menu.gameObject.SetActive(true);
        _menu.anchoredPosition = new Vector2(_hidePos, 0);
        _menu.DOAnchorPosX(_showPos, 0.2f).SetEase(Ease.Linear);

    }

    protected override void HidePanel()
    {
        _menu.anchoredPosition = new Vector2(_showPos, 0);
        _menu.DOAnchorPosX(_hidePos, 0.2f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _menu.gameObject.SetActive(false);
            });
    }

}
