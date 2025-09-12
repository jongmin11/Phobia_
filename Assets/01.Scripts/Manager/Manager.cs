using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager _instance;
    public static Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                var managerObject = new GameObject("Manager");
                _instance = managerObject.AddComponent<Manager>();
                DontDestroyOnLoad(managerObject);
            }
            return _instance;
        }
    }

    [SerializeField] private UIManager _ui;
    [SerializeField] private GameManager _game;
    [SerializeField] private AudioManager _audio;
    [SerializeField] private ResourceManager _resource;
    [SerializeField] private SceneLoadManager _scene;
    [SerializeField] private PlayerManager _playerManager;
    public static UIManager UI
    {
        get
        {
            if (Instance._ui == null)
                Instance._ui = Instance.GetOrAddComponent<UIManager>();
            return Instance._ui;
        }
    }

    public static GameManager Game
    {
        get
        {
            if (Instance._game == null)
                Instance._game = Instance.GetOrAddComponent<GameManager>();
            return Instance._game;
        }
    }

    public static AudioManager Audio
    {
        get
        {
            if (Instance._audio == null)
                Instance._audio = Instance.GetOrAddComponent<AudioManager>();
            return Instance._audio;
        }
    }

    public static ResourceManager Resource
    {
        get
        {
            if (Instance._resource == null)
                Instance._resource = Instance.GetOrAddComponent<ResourceManager>();
            return Instance._resource;
        }
    }

    public static SceneLoadManager Scene
    {
        get
        {
            if (Instance._scene == null)
                Instance._scene = Instance.GetOrAddComponent<SceneLoadManager>();
            return Instance._scene;
        }
    }

    public static PlayerManager PlayerManager
    {
        get
        {
            if (Instance._playerManager == null)
                Instance._playerManager = Instance.GetOrAddComponent<PlayerManager>();
            return Instance._playerManager;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    //컴포넌트가 없으면 가져오고 없으면 생성해서 가져옴
    private T GetOrAddComponent<T>() where T : Component
    {
        var comp = GetComponentInChildren<T>(true);
        if (comp == null)
            comp = gameObject.AddComponent<T>();
        return comp;
    }
}
