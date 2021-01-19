using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public DieOrWinPanelController DieOrWinPanelController;
    public LoadSceneManager LoadSceneManager;
    public Camera MainCamera;
    public GameObject Camera;
    public GameObject UIPlayerCanvas;
    public Transform EndCameraPos;
    public Transform Armature;
    [SerializeField] private LayerMask cameraCullingMask;

    public Rigidbody[] bonesRigidBody;

    private float _lifes = 2f;
    private float _totalLifes;

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerGetHit;
    public static event PlayerDelegate OnPlayerStandUpAfterGetHit;
    public static event PlayerDelegate OnPlayerDie;

    private void Start()
    {
        _totalLifes = _lifes;
    }

    public void Hit() {
        _totalLifes--;
        if(_totalLifes <= 0) {
            Die();
        } else {
            StartCoroutine(DisableMoveFunctionsCoroutine());
        }
    }

    private void Die() {
        UIPlayerCanvas.SetActive(false);
        foreach(Rigidbody rb in bonesRigidBody) {
            rb.isKinematic = false;
        }
        MainCamera.gameObject.transform.position = EndCameraPos.position;
        MainCamera.cullingMask = cameraCullingMask;
        OnPlayerDie();
        StartCoroutine(DelayLookAtAndDiePanel());
    }

    private IEnumerator DelayLookAtAndDiePanel() {
        yield return new WaitForSeconds(0.5f);
        Camera.transform.LookAt(Armature.position);
        yield return new WaitForSeconds(3f);
        DieOrWinPanelController.ActivateDiePanel();
        LoadSceneManager.LoadMainMenu();
    }

    private IEnumerator DisableMoveFunctionsCoroutine() {
        OnPlayerGetHit();
        while(true) {
            if(!PlayerCameraController.GetBoolIsPlayGetHitAnim()) {
                OnPlayerStandUpAfterGetHit();
                yield break;
            }
            yield return null;
        }
    }
}

public abstract class PlayerGetHitEventClass : MonoBehaviour {

    private void Awake() {
        PlayerState.OnPlayerGetHit += DisableFunctions;
        PlayerState.OnPlayerStandUpAfterGetHit += ActivateFunctions;
    }

    public virtual void DisableAddFunctions() { }

    public virtual void ActivateAddFunctions() { }

    public void DisableFunctions() {
        DisableAddFunctions();
        enabled = false;
    }

    public void ActivateFunctions() {
        ActivateAddFunctions();
        enabled = true;
    }
}
