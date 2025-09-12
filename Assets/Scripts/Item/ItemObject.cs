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
            var evidenceUI = Manager.UI.Get<EvidenceInventoryUI>() 
                            ?? Manager.UI.Show<EvidenceInventoryUI>("EvidenceInventoryUI", eAssetType.Prefabs, eCategoryType.UI);

            evidenceUI.AddItem(itemData);
        }
        else
        {
            var invUI = Manager.UI.Get<InventoryUI>() 
                        ?? Manager.UI.Show<InventoryUI>("InventoryUI", eAssetType.Prefabs, eCategoryType.UI);

            invUI.AddItem(itemData);
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
    public void Drop(Vector3 dir, float force, float torque)
    {
        var rb = GetComponent<Rigidbody>();
        if (!rb) return;

        rb.AddForce(dir.normalized * force, ForceMode.Impulse);
        rb.AddTorque(Random.onUnitSphere * torque, ForceMode.Impulse);
    }
}
