using UnityEngine;

public enum ItemType
{
    Key,
    Consumable
}
public enum ItemUsageType
{
    None,       // 효과 없음
    Sanity,     // 정신력 회복
    Stamina,    // 스테미나 회복
    Inventory   // 가방 칸 증가
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