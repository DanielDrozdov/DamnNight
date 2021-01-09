using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateController : MonoBehaviour
{
    public bool IsMonsterRun;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void HitPlayer(GameObject player) {
        IsMonsterRun = false;
        player.GetComponent<PlayerState>().Hit();
        animator.SetTrigger("IsAttack");
    }

    private void FixedUpdate() {
        animator.SetBool("IsRun", IsMonsterRun);
    }
}
