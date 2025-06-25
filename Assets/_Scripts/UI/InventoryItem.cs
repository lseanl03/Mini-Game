using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private ItemConfig _itemConfig;
    [SerializeField] private Image _itemIconImage;
    [SerializeField] private TextMeshProUGUI _nameText, _descriptionText;
    [SerializeField] private Button _itemButton;

    private void Awake()
    {
        _itemButton.onClick.AddListener(OnItemClick);
    }
    public void Init(ItemConfig itemConfig)
    {
        _itemConfig = itemConfig;
        _itemIconImage.sprite = _itemConfig.itemSprite;
        _nameText.text = _itemConfig.itemName;
        _descriptionText.text = _itemConfig.description;
    }

    private void OnItemClick()
    {
        EventManager.OnInventoryItemClick?.Invoke(_itemConfig);
    }
}
