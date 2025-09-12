using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float CurValue;
    public float StartValue;
    public float MaxValue;
    public float PassiveValue;
    public Image UiBar;

    // Start is called before the first frame update
    void Start()
    {
        CurValue = StartValue;
    }

    // Update is called once per frame
    void Update()
    {
        UiBar.fillAmount = GetPercentage();
    }

    float GetPercentage()
    {
        return CurValue / MaxValue;
    }

    public void Add(float value)
    {
        CurValue = Mathf.Min(CurValue + value, MaxValue);
    }

    public void Subtract(float value)
    {
        CurValue = Mathf.Max(CurValue - value, 0);
    }
}
