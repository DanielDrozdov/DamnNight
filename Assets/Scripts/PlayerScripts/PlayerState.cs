using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Rigidbody[] bonesRigidBody;
    public Collider[] bonesColiders;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetAnimation();
    }

    private void EnableBonesRigidBody()
    {
        foreach (Rigidbody rb in bonesRigidBody)
        {
            
        }
    }

    private void Die()
    {
        foreach(Rigidbody rb in bonesRigidBody)
        {
            animator.enabled = false;
            rb.isKinematic = false;
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
