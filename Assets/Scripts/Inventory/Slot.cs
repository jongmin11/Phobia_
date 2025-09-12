using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image icon;
    private ItemData itemData;
    public ItemData ItemData => itemData;

    public bool IsEmpty => itemData == null;

    public void SetItem(ItemData data)
    {
        itemData = data;
        icon.sprite = data.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        itemData = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public virtual void UseItem()
    {
        if (IsEmpty) return;

        Debug.Log($"아이템 사용: {itemData.itemName}");

        switch (itemData.itemUsageType)
        {
            case ItemUsageType.Sanity:
                // Manager.PlayerManager.Player.Condition.conditionUI.Mentality.Add(itemData.value);
                Debug.Log($"정신력 {itemData.value} 회복");
                ClearSlot();
                break;

            case ItemUsageType.Stamina:
                // Manager.PlayerManager.Player.Condition.conditionUI.Stamina.Add(itemData.value);
                Debug.Log($"스태미나 {itemData.value} 회복");
                ClearSlot();
                break;

            case ItemUsageType.Inventory:
                Manager.UI.InventoryUI.AddSlot();
                Debug.Log($"인벤토리 {itemData.value} 칸 증가");
                ClearSlot();
                break;

            case ItemUsageType.Battery:
                Debug.Log("배터리 교체");
                //TODO : 플래시라이트 로직과 연결 필요
                ClearSlot();
                break;

            case ItemUsageType.Key:
                Debug.Log("문 열기");
                //TODO : 문여는 로직과 연결 필요
                ClearSlot();
                break;
        }
    }
    public virtual void DropItem(Vector3 dropPosition)
    {
        if (IsEmpty) return;

        var prefab = Resources.Load<ItemObject>("Prefabs/Items/ItemObjectPrefab");
        if (prefab != null)
        {
            var dropped = Object.Instantiate(prefab, dropPosition, Quaternion.identity);
            dropped.SetData(itemData);

            var cam = Camera.main;
            Vector3 dir = cam ? cam.transform.forward : Vector3.forward;
            dropped.Drop(dir + Vector3.up * 0.2f, 4f, 2f);
        }

        ClearSlot();
    }

}
