using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Prefabs")]
    [SerializeField] private GameObject startSceneUIPrefab;
    [SerializeField] private GameObject inventoryUIPrefab;
    [SerializeField] private GameObject evidenceInventoryUIPrefab;


    public StartSceneUI StartSceneUI { get; private set; }
    public InventoryUI InventoryUI { get; private set; }
    public EvidenceInventoryUI EvidenceInventoryUI { get; private set; }
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
                Show<EvidenceInventoryUI>("EvidenceInventoryUI",eAssetType.Prefabs,eCategoryType.UI);
                Show<InventoryUI>("InventoryUI",eAssetType.Prefabs,eCategoryType.UI);
                break;
        }
    }
    public T Show<T>(string key, eAssetType type, eCategoryType categoryType) where T : UIBase
    {
        var uiPrefab = Manager.Resource.LoadAsset<T>(key, type, categoryType);
        if (uiPrefab == null)
        {
            Debug.LogError($"UIManager: {key} 프리팹 로드 실패");
            return null;
        }

        var instance = Instantiate(uiPrefab);

        if (instance is InventoryUI inv)
            InventoryUI = inv;

        if (instance is EvidenceInventoryUI evidenceInv)
            EvidenceInventoryUI = evidenceInv;

        return instance;
    }

}
