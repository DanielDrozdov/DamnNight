using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMoveController : MonoBehaviour {
    [SerializeField] private Transform[] MonsterSavePoints;
    [SerializeField] private Transform player;
    private NavMeshAgent navMesh;
    private MonsterStateController MonsterStateController;
    private Transform seenPlayer;

    private static MonsterMoveController Instance;

    private float _minHitDistance = 3f;
    private bool IsPlayerDetected;
    private bool IsPlayerHit;

    void Start() {
        navMesh = GetComponent<NavMeshAgent>();
        MonsterStateController = GetComponent<MonsterStateController>();
        Instance = this;
        PickupAndActivateNoteController.OnPickupNote += MoveToNextPosition;
    }

    private MonsterMoveController() { }

    public static MonsterMoveController GetInstance() {
        return Instance;
    }

    public void MoveToNextFarPoint() {
        MoveToNextPosition(CheckNearestPointFromPlayer());
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            seenPlayer = other.transform;
            IsPlayerDetected = true;
            StartCoroutine(MoveToSeenPlayerAndCheckHitDistanceCourutine());
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            IsPlayerDetected = false;
        }
    }

    private IEnumerator MoveToSeenPlayerAndCheckHitDistanceCourutine() {
        while(true) {
            MoveToNextPosition(seenPlayer.position);
            CheckHitDistanceBetweenPlayerAndMonster();
            if(IsPlayerHit || !IsPlayerDetected) {
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
            MoveToNextPosition(transform.position);
            IsPlayerHit = true;
            MonsterStateController.HitPlayer(seenPlayer.gameObject);
        }
    }

    private Vector3 CheckNearestPointFromPlayer() {
        float minDistance = Vector3.Distance(player.position, MonsterSavePoints[0].position);
        Vector3 minVector = MonsterSavePoints[0].position;
        foreach(Transform vector in MonsterSavePoints) {
            float distance = Vector3.Distance(player.position, vector.position);
            if(distance < minDistance) {
                minDistance = distance;
                minVector = vector.position;
            }
        }
        return minVector;
    }

}
