using UnityEngine;
using UnityEngine.UI;

public class EvidenceSlot : Slot
{
    [SerializeField] private Button slotButton;

    private void Awake()
    {
        if (slotButton == null)
            slotButton = GetComponent<Button>();

        if (slotButton != null)
            slotButton.onClick.AddListener(OnClickSlot);
    }

    private void OnClickSlot()
    {
        if (IsEmpty) return;

        // 증거물 정보 UI 띄우기
        var evidenceUI = Manager.UI.Get<EvidenceInventoryUI>() 
                 ?? Manager.UI.Show<EvidenceInventoryUI>("EvidenceInventoryUI", eAssetType.Prefabs, eCategoryType.UI);

        evidenceUI.ShowEvidenceInfo(ItemData);
    }

    public override void UseItem()
    {
        Debug.Log("증거물은 사용할 수 없습니다.");
    }

    public override void DropItem(Vector3 dropPosition)
    {
        Debug.Log("증거물은 버릴 수 없습니다.");
    }
}
