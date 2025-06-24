using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : PanelBase
{
    [SerializeField] private Button _closeButton;

    protected override void Awake()
    {
        _hidePos = -350;
        _showPos = 300;
        _closeButton.onClick.AddListener(OnCloseButtonClick);
        
        base.Awake();
    }

    private void OnCloseButtonClick()
    {
        PanelState(false);
    }

    protected override void ShowPanel()
    {
        base.ShowPanel();
        _menu.DOAnchorPosX(_showPos, 0.2f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _bgButton.gameObject.SetActive(true);
            });
    }
    protected override void HidePanel()
    {
        base.HidePanel();
        _menu.DOAnchorPosX(_hidePos, 0.2f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _menu.gameObject.SetActive(false);
            });
    }
}
