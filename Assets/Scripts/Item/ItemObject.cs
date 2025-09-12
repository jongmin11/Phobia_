using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    public ItemData Data => itemData;
    public void PickUp()
    {
        if (Data == null) return;
        if (itemData.itemType == ItemType.Evidence)
        {
            if (Manager.UI.EvidenceInventoryUI != null)
            {
                Manager.UI.EvidenceInventoryUI.AddItem(itemData);
            }
            else
            {
                Debug.LogWarning("EvidenceInventoryUI가 연결되어 있지 않습니다!");
            }
        }
        else // 일반 아이템은 기본 인벤토리로
        {
            if (Manager.UI.InventoryUI != null)
            {
                Manager.UI.InventoryUI.AddItem(itemData);
            }
            else
            {
                Debug.LogWarning("InventoryUI가 연결되어 있지 않습니다!");
            }
        }

        Destroy(gameObject);
    }

    public void SetData(ItemData data)
    {
        itemData = data;
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null && data.icon != null)
        {
            sr.sprite = data.icon;
        }
    }
    public void Launch(Vector3 dir, float force, float torque)
    {
        var rb = GetComponent<Rigidbody>();
        if (!rb) return;

        rb.AddForce(dir.normalized * force, ForceMode.Impulse);
        rb.AddTorque(Random.onUnitSphere * torque, ForceMode.Impulse);
    }
}
