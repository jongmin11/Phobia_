using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image icon;
    private Sprite itemSprite;

    public bool IsEmpty => itemSprite == null;

    public void SetItem(Sprite sprite)
    {
        itemSprite = sprite;
        icon.sprite = itemSprite;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        itemSprite = null;
        icon.sprite = null;
        icon.enabled = false;
    }
    public void UseItem()
    {
        if (IsEmpty) return;
        Debug.Log($"아이템 사용: {itemSprite.name}");

        // 여기에 아이템 사용효과처리

        ClearSlot();
    }
    public void DropItem() {
        if (IsEmpty) return;
        Debug.Log($"아이템 버림: {itemSprite.name}");

        // 여기에 아이템 버리는 효과처리

        ClearSlot();
    }
}