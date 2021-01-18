using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateController : MonoBehaviour
{
    public bool IsMonsterRun;
    private Animator animator;
    private float _animationTransitionCheckDelay = 0.5f;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        animator.SetBool("IsRun", IsMonsterRun);
    }

    public void HitPlayer(GameObject player) {
        IsMonsterRun = false;
        player.GetComponent<PlayerState>().Hit();
        animator.SetTrigger("IsAttack");
        StartCoroutine(IsCurrentAttackAnim());
    }

    private IEnumerator IsCurrentAttackAnim() {
        yield return new WaitForSeconds(_animationTransitionCheckDelay);
        while(true) {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
                MonsterMoveController.GetInstance().MoveToNextFarPoint();
                yield break;
            }
            yield return null;
        }
    }
}
