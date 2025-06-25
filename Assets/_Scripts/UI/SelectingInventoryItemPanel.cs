using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectingInventoryItemPanel : PanelBase
{
    private ItemConfig _itemConfig;
    [SerializeField] private TextMeshProUGUI _nameText, _descriptionText;
    [SerializeField] private Image _itemIconImage;
    [SerializeField] private Button _bgButton;

    protected override void Awake()
    {
        _bgButton.gameObject.SetActive(false);
        _bgButton.onClick.AddListener(OnCloseClick);
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.OnInventoryItemClick += OnInventoryItemClick;

    }
    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.OnInventoryItemClick -= OnInventoryItemClick;
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
        _canvasGroup.DOFade(0, 0.2f).OnComplete(() =>
        {
            _menu.gameObject.SetActive(false);
            _bgButton.gameObject.SetActive(false);
        });
    }

    private void OnInventoryItemClick(ItemConfig itemConfig)
    {
        PanelState(true);
        GetInfo(itemConfig);
    }

    public void GetInfo(ItemConfig itemConfig)
    {
        _itemConfig = itemConfig;
        _nameText.text = _itemConfig.itemName;
        _descriptionText.text = _itemConfig.description;
        _itemIconImage.sprite = _itemConfig.itemSprite;
    }
}
