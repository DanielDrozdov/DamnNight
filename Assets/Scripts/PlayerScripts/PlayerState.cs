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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Die();
        }
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
}
