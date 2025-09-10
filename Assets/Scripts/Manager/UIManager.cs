using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Prefabs")]
    [SerializeField] private GameObject startSceneUIPrefab;
    [SerializeField] private GameObject inventoryUIPrefab;

    public StartSceneUI StartSceneUI { get; private set; }
    public InventoryUI InventoryUI { get; private set; }
    void Awake()
    {
        // 씬 로드될 때 자동으로 UI 세팅
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    //씬로드시 씬마다 필요한 UI사용
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "InventoryTest": //일단 임시
                Show<InventoryUI>();
                break;
        }
    }

    public T Show<T>() where T : UIBase
    {
        var ui = Manager.Resource.LoadUI<T>();
        var instance = Instantiate(ui);

        if (instance is InventoryUI inv)
            InventoryUI = inv;
        
        return instance;
    }
}
