using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour{
    private float sensivity = 0.3f;
    public readonly float maxVertDegrees = 60f;
    private float minimumVert;
    private float maximumVert;
    private float _rotationX = 0;
    private float _rotationY = 0;

    public Transform Camera;

    private bool IsEditor;
    void Start() {
        minimumVert = -maxVertDegrees;
        maximumVert = maxVertDegrees;

        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
            body.freezeRotation = true;


#if UNITY_EDITOR
        IsEditor = true;
        sensivity = 4f;
#endif

    }

    void LateUpdate() {
        if(IsEditor) {
            CalculateXRotation(Input.GetAxis("Mouse X"));
            CalculateYRotation(Input.GetAxis("Mouse Y"));
        }
    }


    private void CalculateXRotation(float delta) {
        _rotationY = transform.localEulerAngles.y + delta * sensivity;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _rotationY, 0), 1);
    }

    private void CalculateYRotation(float delta) {
        _rotationX -= delta * sensivity;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        Camera.rotation = Quaternion.Lerp(Camera.rotation, Quaternion.Euler(_rotationX, _rotationY, 0), 1);
    }
    }
