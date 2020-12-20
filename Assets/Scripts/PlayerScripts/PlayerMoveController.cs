using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public FixedJoystick joystick;
    private CharacterController _characterController;
    private float _shiftSpeed = 7f;
    private float _defaultSpeed = 4f;
    public float speed { get; private set; }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveDir = transform.TransformDirection(new Vector3(joystick.Direction.x, -9.8f, joystick.Direction.y));
        if(joystick.Direction.y > 0.8f)
        {
            speed = _shiftSpeed;
        } else
        {
            speed = _defaultSpeed;
        }
        _characterController.Move(moveDir * _shiftSpeed * Time.deltaTime);
    }
}
