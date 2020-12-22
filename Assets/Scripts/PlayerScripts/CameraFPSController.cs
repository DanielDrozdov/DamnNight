using UnityEngine;
using UnityEngine.EventSystems;

public class CameraFPSController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [HideInInspector]
    public Vector2 TouchDist;
    [HideInInspector]
    public Vector2 PointerOld;
    [HideInInspector]
    protected int PointerId;
    [HideInInspector]
    public bool Pressed;

    private float sensivity = 0.5f;
    public readonly float maxVertDegrees = 60f;
    private float minimumVert;
    private float maximumVert;
    private float _rotationX = 0;
    private float _rotationY = 0;

    public Transform Camera;
    public Transform Player;

    private void Start() {
        minimumVert = -maxVertDegrees;
        maximumVert = maxVertDegrees;
    }


    void Update() {
        if(Pressed) {
            if(PointerId >= 0 && PointerId < Input.touches.Length) {
                TouchDist = Input.touches[PointerId].position - PointerOld;
                PointerOld = Input.touches[PointerId].position;
            } else {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
        } else {
            TouchDist = new Vector2();        
        }
        CalculateXRotation(TouchDist.x);
        CalculateYRotation(TouchDist.y);
    }

    public void OnPointerDown(PointerEventData eventData) {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }


    public void OnPointerUp(PointerEventData eventData) {
        Pressed = false;
    }

    private void CalculateXRotation(float delta) {
        _rotationY = Player.localEulerAngles.y + delta * sensivity;
        Player.rotation = Quaternion.Lerp(Player.rotation, Quaternion.Euler(0, _rotationY, 0), 1);
    }

    private void CalculateYRotation(float delta) {
        _rotationX -= delta * sensivity;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        Camera.rotation = Quaternion.Lerp(Camera.rotation, Quaternion.Euler(_rotationX, _rotationY, 0), 1);
    }

}
