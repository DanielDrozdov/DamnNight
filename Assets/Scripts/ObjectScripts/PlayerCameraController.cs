using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private Animator animator;
    private static bool IsPlayGetHitAnim;

    private void Start() {
        animator = GetComponent<Animator>();
        PlayerState.OnPlayerGetHit += GetHitAnim;
    }

    void FixedUpdate()
    {
        animator.SetInteger("Speed", PlayerMoveController.GetSpeed());
    }

    private void GetHitAnim() {
        animator.SetTrigger("IsGetHit");
        IsPlayGetHitAnim = true;
        StartCoroutine(CheckIsPlayPlayerGetHitCameraAnim());
    }

    private IEnumerator CheckIsPlayPlayerGetHitCameraAnim() {
        int escapeFrames = 20;  // Animation transition delay(around 1 frame with zero fixed duration)
        while(true) {
            escapeFrames--;
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerGetHitCameraAnim")) {
                IsPlayGetHitAnim = true;
            } else if(escapeFrames <= 0) {
                IsPlayGetHitAnim = false;
            }
            yield return null;
        }
    }

    public static bool GetBoolIsPlayGetHitAnim() {
        return IsPlayGetHitAnim;
    }
}
