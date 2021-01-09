using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMoveController : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private MonsterStateController MonsterStateController;
    private Transform seenPlayer;

    private float _minHitDistance = 3f;
    private bool IsPlayerHit;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        MonsterStateController = GetComponent<MonsterStateController>();
        PickupAndActivateNoteController.OnPickupNote += MoveToNextPosition;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            seenPlayer = other.transform;
            StartCoroutine(MoveToSeenPlayerAndCheckHitDistanceCourutine());
        }
    }

    private IEnumerator MoveToSeenPlayerAndCheckHitDistanceCourutine() {
        while(true) {
            MoveToNextPosition(seenPlayer.position);
            CheckHitDistanceBetweenPlayerAndMonster();
            if(IsPlayerHit) {
                IsPlayerHit = false;
                yield break;
            }
            yield return null;
        }
    }

    private void MoveToNextPosition(Vector3 destination) {
        MonsterStateController.IsMonsterRun = true;
        navMesh.destination = destination;
    }

    private void CheckHitDistanceBetweenPlayerAndMonster() {
        float distance = Vector3.Distance(transform.position, seenPlayer.position);
        if(distance <= _minHitDistance) {
            IsPlayerHit = true;
            MonsterStateController.HitPlayer(seenPlayer.gameObject);
        }
    }
}
