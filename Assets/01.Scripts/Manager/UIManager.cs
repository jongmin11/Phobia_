using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
public class UIManager : MonoBehaviour
{
    [Header("UI Prefabs")]
    [SerializeField] private GameObject startSceneUIPrefab;
    [SerializeField] private GameObject inventoryUIPrefab;
    [SerializeField] private GameObject evidenceInventoryUIPrefab;

    private Dictionary<string, UIBase> uiDict = new();

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
        //딕셔너리에 있을경우 생성X
        if (uiDict.TryGetValue(typeof(T).ToString(), out UIBase existing))
        {
            existing.OnShow();
            return (T)existing;
        }
        //딕셔너리에 없을경우 리소스매니저를 통해 로드
        var uiPrefab = Manager.Resource.LoadAsset<T>(key, type, categoryType);
        if (uiPrefab == null)
        {
            Debug.LogError($"UIManager: {key} 프리팹 로드 실패");
            return null;
        }
        //로드 후 딕셔너리에 저장
        var instance = Instantiate(uiPrefab);
        uiDict[typeof(T).ToString()] = instance;
        instance.OnShow();
        return instance;
    }
    public void Hide<T>() where T : UIBase
    {
        if (uiDict.TryGetValue(typeof(T).ToString(), out UIBase ui))
            ui.OnHide();
    }

    public T Get<T>() where T : UIBase
    {
        if (uiDict.TryGetValue(typeof(T).ToString(), out UIBase ui))
            return (T)ui;

        return null;
    }
}
