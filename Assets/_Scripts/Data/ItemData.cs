using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public List<ItemConfig> items;
    public ItemConfig GetItemByType(ItemType itemType)
    {
        return items.Find(item => item.itemType == itemType);
    }


}

[Serializable]
public class ItemConfig
{
    public string itemName;
    public string description;
    public int price;
    public int effectValue;

    public ItemType itemType;
    public Sprite itemSprite;
}
