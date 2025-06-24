using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : PanelBase
{
    [SerializeField] public RectTransform Content;
    [SerializeField] private Button _closeButton, _buyButton;
    [SerializeField] private TextMeshProUGUI _buyPriceText;
    [SerializeField] public SelectingShopItemPanel SelectingShopItemPanel;

    protected override void Awake()
    {
        _hidePos = -350;
        _showPos = 300;
        _buyButton.gameObject.SetActive(false);

        _closeButton.onClick.AddListener(OnCloseClick);
        _buyButton.onClick.AddListener(OnBuyCLick);
        
        base.Awake();
    }

    private void OnCloseClick()
    {
        PanelState(false);
    }

    private void OnBuyCLick()
    {
        SelectingShopItemPanel.PanelState(false);
    }

    protected override void ShowPanel()
    {
        _menu.gameObject.SetActive(true);
        _menu.anchoredPosition = new Vector2(_hidePos, 0);
        _menu.DOAnchorPosX(_showPos, 0.2f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _bg.gameObject.SetActive(true);
            });
    }
    protected override void HidePanel()
    {
        _menu.anchoredPosition = new Vector2(_showPos, 0);
        _menu.DOAnchorPosX(_hidePos, 0.2f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _bg.gameObject.SetActive(false);
                _menu.gameObject.SetActive(false);
            });
    }
    private void SetBuyPriceText(int price)
    {
        _buyPriceText.text = $"Mua bằng {price.ToString()} coin";
    }

    public GameObject BuyButtonObject() => _buyButton.gameObject;

    public void OnShopItemClick(ItemConfig itemConfig)
    {
        _buyButton.gameObject.SetActive(true);
        SelectingShopItemPanel.PanelState(true);

        SetBuyPriceText(itemConfig.price);
        SelectingShopItemPanel.GetInfo(itemConfig);
    }
}
