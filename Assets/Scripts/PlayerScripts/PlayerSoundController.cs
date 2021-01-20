using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : PlayerGetHitEventClass {
    public enum PlatformEnum {
        None,
        Wood
    }

    [SerializeField] private AudioClip GrassRun;
    [SerializeField] private AudioClip GrassWalk;
    [SerializeField] private AudioClip WoodAudio;
    public AudioSource Source;

    private static PlayerSoundController Instance;
    private PlatformEnum platformEnum;

    private void Awake() {
        Instance = this;
        PlayerState.OnPlayerGetHit += DisableFunctions;
        PlayerState.OnPlayerStandUpAfterGetHit += ActivateFunctions;
        PlayerState.OnPlayerDie += DisableAudio;
    }

    private PlayerSoundController() { }

    public static PlayerSoundController GetInstance() {
        return Instance;
    }

    public void EnableOrDisablePlatformSound(PlayerMoveController.MoveState moveState) {
        if(platformEnum == PlatformEnum.Wood && (PlayerMoveController.MoveState.Walk == moveState || PlayerMoveController.MoveState.Run == moveState)) {
            PlayWoodAudio();
        } else if(PlayerMoveController.MoveState.Walk == moveState) {
            PlayGrassWalkAudio();
        } else if(PlayerMoveController.MoveState.Run == moveState) {
            PlayGrassRunAudio();
        } else {
            DisableAudio();
        }
    }

    public void PlayWoodAudio() {
        PlayAudio(WoodAudio);
        platformEnum = PlatformEnum.Wood;
    }

    public void PlayGrassRunAudio() {
        PlayAudio(GrassRun);
    }

    public void PlayGrassWalkAudio() {
        PlayAudio(GrassWalk);
    }

    public void ChangePlatformToNone() {
        platformEnum = PlatformEnum.None;
    }

    private void PlayAudio(AudioClip clip) {
        Source.clip = clip;
        Source.Play();
    }

    private void DisableAudio() {
        Source.clip = null;
    }

    public override void DisableAddFunctions() {
        DisableAudio();
    }

    public override void ActivateAddFunctions() {
        EnableOrDisablePlatformSound(PlayerMoveController.GetPlayerMoveState());
    }
}
