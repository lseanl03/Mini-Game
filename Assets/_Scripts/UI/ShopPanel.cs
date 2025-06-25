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
    [SerializeField] private Button _closeButton;

    protected override void Awake()
    {
        _hidePos = -350;
        _showPos = 300;

        _closeButton.onClick.AddListener(OnCloseClick);
        
        base.Awake();
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
