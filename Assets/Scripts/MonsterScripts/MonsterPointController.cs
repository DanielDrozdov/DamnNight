using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPointController : MonoBehaviour
{
    private MonsterStateController monsterStateController;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Monster")) {
            monsterStateController = other.GetComponent<MonsterStateController>();
            monsterStateController.IsMonsterRun = false;
        }
    }
}
