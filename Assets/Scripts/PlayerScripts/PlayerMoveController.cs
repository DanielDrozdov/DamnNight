using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : PlayerGetHitEventClass {

    public enum MoveState {
        Idle,
        Walk,
        Run
    }

    public FixedJoystick joystick;
    public StaminaBarController StaminaBarController;
    private PlayerSoundController playerSoundController;
    private float inactiveMoveZone = 0.2f;

    private static MoveState moveState;
    private MoveState oldMoveState;
    private static int speed;
    private CharacterController _characterController;
    private int _shiftSpeed = 7;
    private int _defaultSpeed = 4;

    private static float totalStamina;
    private static float staminaReserv = 45f;
    private float _staminaShiftCost = 6f;
    private float _staminaRecovery = 2.5f;
    private float _minShiftStaminaBank = 8f;
    private bool HasNotStamina;

    void Start() {
        _characterController = GetComponent<CharacterController>();
        playerSoundController = PlayerSoundController.GetInstance();
        totalStamina = staminaReserv;      
    }

    void Update() {
        Move();
        IsPlayerChangeSpeed();
        StaminaControll();
    }

    public override void DisableAddFunctions() {
        speed = 0;
        totalStamina = staminaReserv;
        StaminaBarController.UpdateStaminaBar();
    }

    private void StaminaControll() {
        totalStamina = Mathf.Clamp(totalStamina, 0, staminaReserv);
        if(totalStamina != staminaReserv) {
            StaminaBarController.UpdateStaminaBar();
        }
        if(totalStamina <= 0.5) {
            HasNotStamina = true;
        } else if(HasNotStamina && totalStamina >= _minShiftStaminaBank) {
            HasNotStamina = false;
        }
    }

    private void Move() {
        CalculateDirectionAndStaminaState();
        Vector3 moveDir = transform.TransformDirection(new Vector3(joystick.Direction.x, -9.8f, joystick.Direction.y));
        _characterController.Move(moveDir * speed * Time.deltaTime);
    }

    private void CalculateDirectionAndStaminaState() {
        if(joystick.Direction.y <= inactiveMoveZone && joystick.Direction.y >= -inactiveMoveZone &&
            joystick.Direction.x <= inactiveMoveZone && joystick.Direction.x >= -inactiveMoveZone) {
            speed = 0;
            moveState = MoveState.Idle;
            totalStamina += _staminaShiftCost * Time.deltaTime;
        } else if(joystick.Direction.y > 0.75f && !HasNotStamina) {
            speed = _shiftSpeed;
            moveState = MoveState.Run;
            totalStamina -= _staminaShiftCost * Time.deltaTime;
        } else {
            speed = _defaultSpeed;
            moveState = MoveState.Walk;
            totalStamina += _staminaRecovery * Time.deltaTime;
        }
    }

    public static int GetSpeed() {
        return speed;
    }

    public static float GetStaminaReserv() {
        return staminaReserv;
    }

    public static float GetTotalStamina() {
        return totalStamina;
    }

    public static MoveState GetPlayerMoveState() {
        return moveState;
    }

    private void IsPlayerChangeSpeed() {
        if(oldMoveState != moveState) {
            oldMoveState = moveState;
            playerSoundController.EnableOrDisablePlatformSound(moveState);
        }
    }
}


