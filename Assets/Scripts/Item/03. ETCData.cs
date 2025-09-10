using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ETCData", menuName = "ItemData/ETC")]
public class ETCData : ScriptableObject // ETC 아이템 데이터
{
    public GameObject itemObject;
    public string itemName;
    public string description;
    public int chargeMax;
}
