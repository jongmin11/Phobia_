using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class EvidenceInventoryUI : UIBase
{
    [Header("아이템 정보")]
    [SerializeField] private GameObject itemInfoPanel;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemDescription;
    [SerializeField] private Button closeBtn;

    [Header("슬롯 설정")]
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private int initialSlotCount = 4;

    private List<EvidenceSlot> slots = new();
    private bool isOpen = false;

    void Start()
    {
        for (int i = 0; i < initialSlotCount; i++)
        {
            AddSlot();
        }
        if (closeBtn != null)
            closeBtn.onClick.AddListener(CloseInfoPanel);

        OnHide();
    }

    public bool AddItem(ItemData itemData)
    {
        foreach (var slot in slots)
        {
            if (slot == null) continue;

            if (slot.IsEmpty)
            {
                slot.SetItem(itemData);
                return true;
            }
        }
        return true;
    }

    private EvidenceSlot AddSlot()
    {
        GameObject newSlotObj = Instantiate(slotPrefab, slotParent);
        EvidenceSlot newSlot = newSlotObj.GetComponent<EvidenceSlot>();
        slots.Add(newSlot);
        return newSlot;
    }

    public void ToggleUI()
    {
        if (isOpen) OnHide();
        else OnShow();
    }

    public override void OnShow()
    {
        slotParent.gameObject.SetActive(true);
        isOpen = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public override void OnHide()
    {
        slotParent.gameObject.SetActive(false);
        isOpen = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ShowEvidenceInfo(ItemData data)
    {
        if (itemInfoPanel != null)
        {
            itemInfoPanel.SetActive(true);
            if (itemName != null) itemName.text = data.itemName;
            if (itemDescription != null) itemDescription.text = data.description;
        }
    }
    public void CloseInfoPanel()
    {
        if (itemInfoPanel != null)
            itemInfoPanel.SetActive(false);
    }
}
