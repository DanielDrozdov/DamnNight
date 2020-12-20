using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    private float sensitivityHor = 4.0f;
    private float sensitivityVert = 4.0f;
    public readonly float maxVertDegrees = 60f;
    private float minimumVert;
    private float maximumVert;
    private float _rotationX = 0;
    private float _rotationY = 0;



    private bool IsEditor;
    void Start()
    {
        minimumVert = -maxVertDegrees;
        maximumVert = maxVertDegrees;

        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;


#if UNITY_EDITOR
IsEditor = true;
#endif

    }
    void LateUpdate()
    {
        if (IsEditor)
        {
            if (axes == RotationAxes.MouseX)
            {
                CalculateYRotation();
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _rotationY, 0), 1);
            }
            else if (axes == RotationAxes.MouseY)
            {
                CalculateXRotation();
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotationX, _rotationY, 0), 1);
            }
        }
    }
    
    private void CalculateYRotation()
    {
        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        _rotationY = transform.localEulerAngles.y + delta;
    }

    private void CalculateXRotation()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        _rotationY = transform.rotation.eulerAngles.y;
    }
}