using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Prefabs")]
    [SerializeField] private GameObject startSceneUIPrefeb;

    public T Show<T>() where T : UIBase
    {
        var ui = Manager.Resource.LoadUI<T>(); ;
        return Instantiate(ui);
    }
}