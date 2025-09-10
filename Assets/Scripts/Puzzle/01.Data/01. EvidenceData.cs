using UnityEngine;
using UnityEngine.SceneManagement;

// 증거 아이템
[CreateAssetMenu(fileName = "EvidenceData", menuName = "ItemData/Evidence")]
public class EvidenceData : ScriptableObject // 증거 아이템 데이터
{
    public GameObject itemObject;
    public int iD; // 스폰시 필요한 번호
    public string itemName;
    [TextArea] public string Description;
    public bool isEnding;

    public bool CheckEnding()
    {
        return isEnding;
    }
}

