using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Dictionary<string, UIBase> UIList = new Dictionary<string, UIBase>();

    public T LoadUI<T>() where T : UIBase
    {
        if (UIList.ContainsKey(typeof(T).Name))
            return UIList[typeof(T).Name] as T;

        //딕셔너리에 값이 없으면 로드
        var ui = Resources.Load<UIBase>($"Prefabs/UI/{typeof(T).Name}") as T;
        if (ui == null)
        {
            Debug.LogError("UI 프리팹이 없습니다");
            return null;
        }
        UIList.Add(ui.name, ui);
        return ui;
    }
}
