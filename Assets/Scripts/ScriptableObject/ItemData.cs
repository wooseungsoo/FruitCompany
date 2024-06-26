using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum ItemType
{
    Equipable,
    Resource
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType Type;
    public Sprite icon;
    public Object dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;
}
