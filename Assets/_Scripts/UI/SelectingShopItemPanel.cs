using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectingShopItemPanel : PanelBase
{
    [SerializeField] private TextMeshProUGUI _nameText, _descriptionText;
    [SerializeField] private Image _itemIconImage;

    public void GetInfo(ItemConfig itemConfig)
    {
        _nameText.text = itemConfig.itemName;
        _descriptionText.text = itemConfig.description;
        _itemIconImage.sprite = itemConfig.itemSprite;
    }

    protected override void ShowPanel()
    {
        _bg.gameObject.SetActive(true);
        _menu.gameObject.SetActive(true);
        _canvasGroup.alpha = 0f;

        _canvasGroup.DOFade(1f, 0.2f);
    }

    protected override void HidePanel()
    {
        UIManager.Instance.ShopPanel.BuyButtonObject().SetActive(false);

        _canvasGroup.DOFade(0, 0.2f).OnComplete(() =>
        {
            _bg.gameObject.SetActive(false);
            _menu.gameObject.SetActive(false);
        });
    }
}
