using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    // UI가 열릴 때 호출
    public virtual void OnShow()
    {
        gameObject.SetActive(true);
    }

    // UI가 닫힐 때 호출
    public virtual void OnHide()
    {
        gameObject.SetActive(false);
    }

    // UI를 완전히 제거할 때 호출
    public virtual void OnClose()
    {
        Destroy(gameObject);
    }

    // UI 초기화
    public virtual void Init(params object[] args)
    {
        // 자식 클래스에서 구현
    }
}
