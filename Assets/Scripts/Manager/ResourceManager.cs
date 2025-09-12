using System.Collections.Generic;
using UnityEngine;
public enum eAssetType
{
    Prefabs,
    Data,
}
public enum eCategoryType
{
    None,
    UI,
    Items
}
public class ResourceManager : MonoBehaviour
{
    public T LoadAsset<T>(string key, eAssetType assetType , eCategoryType categoryType = eCategoryType.None) where T : Object
    {
        string path = $"{assetType}{(categoryType == eCategoryType.None ? "" : $"/{categoryType}")}/{key}";
        var obj = Resources.Load(path, typeof(T));

        if (obj == null)
        {
            Debug.LogError($"ResourceManager: {path} 로드 실패");
            return null;
        }

        return obj as T;
    }
}
