using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 소비 아이템
[CreateAssetMenu(fileName = "ConsumeData", menuName = "ItemData/Consume")]
public class ConsumeData : ScriptableObject // 소비 아이템 데이터 
{
    public GameObject itemObject;
    public string itemName;
    public string Description;
    public float drug; // 회복량
}
