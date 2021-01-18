using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMonsterSoundController : MonoBehaviour
{
    public GameObject MonsterSound;
    private int _enterInZoneTriesCount = 1;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && _enterInZoneTriesCount == 1) {
            _enterInZoneTriesCount--;
            MonsterSound.SetActive(true);
            Destroy(gameObject, 7f);
            Destroy(MonsterSound, 7f);
        }
    }
}
