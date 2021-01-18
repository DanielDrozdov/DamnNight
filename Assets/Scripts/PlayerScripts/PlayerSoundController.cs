﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
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
    }

    private PlayerSoundController() { }

    public static PlayerSoundController GetInstance() {
        return Instance;
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

    public void EnableOrDisablePlatformSound(PlayerMoveController.MoveState moveState) {
        if(platformEnum == PlatformEnum.Wood) {
            PlayWoodAudio();
        } else if(PlayerMoveController.MoveState.Walk == moveState) {
            PlayGrassWalkAudio();
        } else if(PlayerMoveController.MoveState.Run == moveState) {
            PlayGrassRunAudio();
        } else {
            Source.clip = null;
        }
    }

    private void PlayAudio(AudioClip clip) {
        Source.clip = clip;
        Source.Play();
    }


}
