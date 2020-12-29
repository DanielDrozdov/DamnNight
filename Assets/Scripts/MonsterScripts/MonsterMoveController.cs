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
    }

    
    void Update()
    {
        MoveToNextPosition();
    }

    private void MoveToNextPosition() {
        navMesh.destination = position.position;
    }
}
