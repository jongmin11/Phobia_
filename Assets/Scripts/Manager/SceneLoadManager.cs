using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
    public async void LoadScene(string sceneName)
    {
        var loadOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!loadOp.isDone)
        {
            await Task.Yield();
        }
        Debug.Log($"Scene Loaded: {sceneName}");
    }

}
