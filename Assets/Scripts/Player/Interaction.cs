using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    //캐싱
    public GameObject CurInteractGameObject;
    //private IInteractable CurInteractable;

    private Camera camera;



    void Start()
    {
        camera = Camera.main;
    }


    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * maxCheckDistance, Color.red, checkRate);

            // 레이캐스트를 발사해서 상호작용 물체 인식하기
            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != CurInteractGameObject)
                {
                    CurInteractGameObject = hit.collider.gameObject;
                    //CurInteractable = hit.collider.GetComponent<IInteractable>();
                    //위 정보를 담아뒀다면 프롬프트에 출력해라
                }
            }
            else
            {
                CurInteractGameObject = null;
                //CurInteractable = null;
                //프롬프트 끄기
            }
        }

    }

    private void SetPromptText()
    {
        
    }

    public void OnInteractInput()
    {
        if(CurInteractGameObject != null)
        {
            //CurInteractGameObject.OnInteract();
            CurInteractGameObject = null;
            //CurInteractable = null;
            //프롬프트 끄기
        }
    }
}
