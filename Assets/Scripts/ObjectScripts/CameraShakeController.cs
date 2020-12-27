using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        animator.SetInteger("Speed", PlayerMoveController.speed);
    }
}
