using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMoveController : MonoBehaviour
{
    private NavMeshAgent navMesh;
    public Transform position;
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        PickupAndActivateNoteController.OnPickupNote += MoveToNextPosition;
    }

    private void MoveToNextPosition(Vector3 destination) {
        navMesh.destination = destination;
    }
}
