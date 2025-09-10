using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Sprite testItemSprite; // 임시 아이템

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Manager.UI.InventoryUI.AddItem(testItemSprite);
        }
    }
}
