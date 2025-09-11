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
    [SerializeField] private PlayerManager _playerManager; // Player라는 스크립트가 있어서 Manager명칭까지 정확하게 사용
    
    public static UIManager UI => Instance._ui;
    public static GameManager Game => Instance._game;
    public static AudioManager Audio => Instance._audio;
    public static ResourceManager Resource => Instance._resource;
    public static SceneLoadManager Scene => Instance._scene;
    public static PlayerManager PlayerManager => Instance._playerManager;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        if (_ui == null) _ui = GetComponentInChildren<UIManager>(true);
        if (_game == null) _game = GetComponentInChildren<GameManager>(true);
        if (_audio == null) _audio = GetComponentInChildren<AudioManager>(true);
        if (_resource == null) _resource = GetComponentInChildren<ResourceManager>(true);
        if (_scene == null) _scene = GetComponentInChildren<SceneLoadManager>(true);
        if(_playerManager == null) _playerManager = GetComponentInChildren<PlayerManager>(true);
    }
}

