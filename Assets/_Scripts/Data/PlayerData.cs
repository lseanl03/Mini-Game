using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string Name;
    public int Level;
    public int MaxHealth;
    public List<ItemConfig> InventoryItemList;
}
