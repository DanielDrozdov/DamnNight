using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

    public FixedJoystick joystick;
    private float inactiveMoveZone = 0.2f;

    public static int speed { get; private set; }
    private CharacterController _characterController;
    private int _shiftSpeed = 7;
    private int _defaultSpeed = 4;

    public static float totalStamina { get; private set; }
    public static float staminaReserv { get; private set; } = 45f;
    private float _staminaShiftCost = 6f;
    private float _staminaRecovery = 2.5f;
    private float _minShiftStaminaBank = 8f;
    private bool HasNotStamina;

    void Start() {
        _characterController = GetComponent<CharacterController>();
        totalStamina = staminaReserv;
    }

    void Update() {
        Vector3 moveDir = transform.TransformDirection(new Vector3(joystick.Direction.x, 0, joystick.Direction.y));
        if(joystick.Direction.y <= inactiveMoveZone && joystick.Direction.y >= -inactiveMoveZone &&
            joystick.Direction.x <= inactiveMoveZone && joystick.Direction.x >= -inactiveMoveZone) {
            speed = 0;
            totalStamina += _staminaShiftCost * Time.deltaTime;
        } else if(joystick.Direction.y > 0.75f && !HasNotStamina) {
            speed = _shiftSpeed;
            totalStamina -= _staminaShiftCost * Time.deltaTime;
        } else {
            speed = _defaultSpeed;
            totalStamina += _staminaRecovery * Time.deltaTime;
        }
        StaminaControll();
        _characterController.Move(moveDir * speed * Time.deltaTime);
    }

    private void StaminaControll() {
        totalStamina = Mathf.Clamp(totalStamina, 0, staminaReserv);
        if(totalStamina <= 0.5) {
            HasNotStamina = true;
        } else if(HasNotStamina && totalStamina >= _minShiftStaminaBank) {
            HasNotStamina = false;
        }
    }
}
