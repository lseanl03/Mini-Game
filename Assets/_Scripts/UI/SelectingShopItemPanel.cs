using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectingShopItemPanel : PanelBase
{
    private ItemConfig _itemConfig;
    [SerializeField] private TextMeshProUGUI _nameText, _descriptionText, _buyPriceText;
    [SerializeField] private Image _itemIconImage;
    [SerializeField] private Button _bgButton, _buyButton;


    protected override void Awake()
    {
        _bgButton.gameObject.SetActive(false);
        _buyButton.gameObject.SetActive(false);

        _bgButton.onClick.AddListener(OnCloseClick);
        _buyButton.onClick.AddListener(OnBuyShopItemCLick);

        base.Awake();
    }
    private void OnBuyShopItemCLick()
    {
        PanelState(false);
        EventManager.OnBuyShopItem?.Invoke(_itemConfig);
    }

    public void GetInfo(ItemConfig itemConfig)
    {
        _itemConfig = itemConfig;
        _nameText.text = itemConfig.itemName;
        _descriptionText.text = itemConfig.description;
        _itemIconImage.sprite = itemConfig.itemSprite;
    }

    protected override void ShowPanel()
    {
        _menu.gameObject.SetActive(true);
        _bgButton.gameObject.SetActive(true);

        _canvasGroup.alpha = 0f;
        _canvasGroup.DOFade(1f, 0.2f);
    }

    protected override void HidePanel()
    {
        _buyButton.gameObject.SetActive(false);

        _canvasGroup.DOFade(0, 0.2f).OnComplete(() =>
        {
            _menu.gameObject.SetActive(false);
            _bgButton.gameObject.SetActive(false);
        });
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.OnBuyShopItem += OnBuyShopItem;
        EventManager.OnShopItemClick += OnShopItemClick;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.OnBuyShopItem -= OnBuyShopItem;
        EventManager.OnShopItemClick -= OnShopItemClick;
    }
    private void OnShopItemClick(ItemConfig itemConfig)
    {
        _buyButton.gameObject.SetActive(true);

        PanelState(true);
        GetInfo(itemConfig);
        SetBuyPriceText(itemConfig.price);
    }
    private void OnBuyShopItem(ItemConfig itemConfig)
    {
    }

    public void SetBuyPriceText(int price)
    {
        _buyPriceText.text = $"Mua bằng {price.ToString()} coin";
    }

}
