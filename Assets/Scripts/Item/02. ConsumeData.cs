using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Һ� ������
[CreateAssetMenu(fileName = "ConsumeData", menuName = "ItemData/Consume")]
public class ConsumeData : ScriptableObject // �Һ� ������ ������ 
{
    public GameObject itemObject;
    public string itemName;
    public string Description;
    public float drug; // ȸ����
}
