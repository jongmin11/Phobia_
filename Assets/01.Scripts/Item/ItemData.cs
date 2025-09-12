using UnityEngine;

public enum ItemType
{
    Evidence,
    Consumable
}
public enum ItemUsageType
{
    None,
    Sanity,
    Stamina,
    Inventory,
    Battery,
    Key
}


[CreateAssetMenu(menuName = "Item/ItemData", fileName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("정보")]
    public string itemName;
    public Sprite icon;
    public ItemType itemType;
    [TextArea] public string description;

    [Header("소비 아이템 전용")]
    public ItemUsageType itemUsageType;
    public int value;
}