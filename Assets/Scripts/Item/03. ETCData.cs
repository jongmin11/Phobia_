using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ETCData", menuName = "ItemData/ETC")]
public class ETCData : ScriptableObject // ETC ������ ������
{
    public GameObject itemObject;
    public string itemName;
    public string description;
    public int chargeMax;
}
