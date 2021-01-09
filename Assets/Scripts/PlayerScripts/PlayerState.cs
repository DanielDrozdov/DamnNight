using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Rigidbody[] bonesRigidBody;
    public Collider[] bonesColiders;
    private Animator animator;

    private float _lifes = 2f;
    private float _totalLifes;

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerGetHit;
    public static event PlayerDelegate OnPlayerStandUpAfterGetHit;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _totalLifes = _lifes;
    }

    private void FixedUpdate()
    {
        SetAnimation();
    }

    private void Die() {
        foreach(Rigidbody rb in bonesRigidBody) {
            animator.enabled = false;
            rb.isKinematic = false;
        }
    }

    public void Hit() {
        _totalLifes--;
        if(_totalLifes <= 0) {
            Die();
        } else {
            StartCoroutine(DisableMoveFunctionsCoroutine());
        }
    }

    private IEnumerator DisableMoveFunctionsCoroutine() {
        OnPlayerGetHit();
        while(true) {
            if(!PlayerCameraController.GetBoolIsPlayGetHitAnim()) {
                OnPlayerStandUpAfterGetHit();
                yield break;
            }
            yield return null;
        }
    }


    private void SetAnimation() {
        if(PlayerMoveController.speed == 0) {
            SetBoolToAnimator(true,false,false);
        } else if(PlayerMoveController.speed == 4) {
            SetBoolToAnimator(false, true, false);
        } else if(PlayerMoveController.speed == 7) {
            SetBoolToAnimator(false, false, true);
        }
    }

    private void SetBoolToAnimator(bool IsIdle,bool IsWalking,bool IsRuning) {
        animator.SetBool("IsIdle", IsIdle);
        animator.SetBool("IsWalking", IsWalking);
        animator.SetBool("IsRuning", IsRuning);
    }
}

public abstract class PlayerGetHitEventClass : MonoBehaviour {

    private void Awake() {
        PlayerState.OnPlayerGetHit += DisableFunctions;
        PlayerState.OnPlayerStandUpAfterGetHit += ActivateFunctions;
    }

    public void DisableFunctions() {
        DisableAddFunctions();
        enabled = false;
    }

    public virtual void DisableAddFunctions() {}

    public void ActivateFunctions() {
        enabled = true;
    }
}
