using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Manager.UI.InventoryUI != null)
            {
                Manager.UI.InventoryUI.AddItem(itemData.icon);
                Debug.Log($"{itemData.itemName} 인벤토리에 추가됨!");
            }

            Destroy(gameObject);
        }
    }
}
