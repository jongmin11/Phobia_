using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private Sprite testItemSprite; // 임시 아이템

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            inventoryUI.AddItem(testItemSprite);
        }
    }
}
