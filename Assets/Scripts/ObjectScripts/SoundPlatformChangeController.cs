using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlatformChangeController : MonoBehaviour
{
    private PlayerSoundController playerSoundController;

    private void Start() {
        playerSoundController = PlayerSoundController.GetInstance();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            playerSoundController.PlayWoodAudio();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            playerSoundController.PlayGrassWalkAudio();
            playerSoundController.ChangePlatformToNone();
        }
    }
}
