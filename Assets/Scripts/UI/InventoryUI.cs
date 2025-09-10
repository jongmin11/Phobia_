using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : UIBase
{
    [SerializeField] private CanvasGroup inventoryUI;
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private int initialSlotCount = 4;
    [SerializeField] private float fadeDuration = 2f;

    private List<Slot> slots = new();

    private int selectedIndex = -1;
    private float normalScale = 1f;
    private float selectedScale = 1.2f;
    private float fadeTimer = 0f;

    void Start()
    {
        // 기본 슬롯 생성
        for (int i = 0; i < initialSlotCount; i++)
        {
            AddSlot();
        }
    }
    void Update()
    {
        fadeTimer += Time.deltaTime;
        if (fadeTimer >= fadeDuration)
        {
            if (inventoryUI.alpha > 0f)
            {
                float fadeSpeed = 1f / fadeDuration; 
                inventoryUI.alpha -= fadeSpeed * Time.deltaTime;
                inventoryUI.alpha = Mathf.Clamp01(inventoryUI.alpha);
            }
        }
        HandleInput();
    }

    public bool AddItem(Sprite itemSprite)
    {
        // 빈 슬롯 찾기
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(itemSprite);
                return true;
            }
        }

        Debug.Log("인벤토리 가득참!");
        return false;
    }

    public void AddSlot()
    {
        GameObject newSlotObj = Instantiate(slotPrefab, slotParent);
        Slot newSlot = newSlotObj.GetComponent<Slot>();
        slots.Add(newSlot);
    }
    public void SelectSlot(int index)
    {
        if (index < 0 || index >= slots.Count) return;
        selectedIndex = index;
        UpdateSlotSelection();
    }

    private void UpdateSlotSelection()
    {
        fadeTimer = 0f;
        inventoryUI.alpha = 1f;
        for (int i = 0; i < slots.Count; i++)
        {
            if (i == selectedIndex)
                slots[i].transform.localScale = Vector3.one * selectedScale;
            else
                slots[i].transform.localScale = Vector3.one * normalScale;
        }
    }
    private void HandleInput()
    {
        // 숫자키 입력 (동적으로 슬롯 수에 맞게 체크)
        for (int i = 0; i < slots.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectSlot(i);
            }
        }

        // 마우스 휠 입력
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            if (selectedIndex == -1) selectedIndex = 0; // 아무것도 선택 안 됐을 때 첫 슬롯 선택
            else selectedIndex = (selectedIndex - 1 + slots.Count) % slots.Count;

            UpdateSlotSelection();
        }
        else if (scroll < 0f)
        {
            if (selectedIndex == -1) selectedIndex = 0;
            else selectedIndex = (selectedIndex + 1) % slots.Count;

            UpdateSlotSelection();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedIndex >= 0 && selectedIndex < slots.Count)
            {
                slots[selectedIndex].UseItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (selectedIndex >= 0 && selectedIndex < slots.Count)
            {
                slots[selectedIndex].DropItem();
            }
        }
    }
}
