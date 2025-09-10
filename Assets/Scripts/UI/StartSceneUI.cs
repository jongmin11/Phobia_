using UnityEngine;
using UnityEngine.UI;

public class StartSceneUI : UIBase
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button exitBtn;
    void Start()
    {
        if (startBtn) startBtn.onClick.AddListener(OnClickStartButton);
        if (settingBtn) settingBtn.onClick.AddListener(OnClickSettingButton);
        if (exitBtn) exitBtn.onClick.AddListener(OnClickExitButton);
    }
    public override void OnShow()
    {
        base.OnShow();
    }

    public override void OnHide()
    {
        base.OnHide();
    }

    public void OnClickStartButton()
    {
        //Manager.Scene.LoadScene("NextScene");
    }
    private void OnClickSettingButton()
    {
       //Manager.UI.Show<SettingUI>(); 나중에 setting ui만들면 진행
    }
    public void OnClickExitButton()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

}
