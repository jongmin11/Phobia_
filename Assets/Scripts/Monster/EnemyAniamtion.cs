using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAniamtion : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetMoving(bool isMoving)
    {
        animator.SetBool("Moving", isMoving);
    }

    public void SetRun(bool isRunning)
    {
        animator.SetBool("Run", isRunning);
    }
    public void PlayRage()
    {
        animator.SetTrigger("Rage");
    }
    public void SetIdle()
    {
        animator.SetBool("Moving", false);
        animator.SetBool("Run", false);
    }
}
