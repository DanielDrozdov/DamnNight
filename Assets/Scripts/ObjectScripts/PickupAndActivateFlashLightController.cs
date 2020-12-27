using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndActivateFlashLightController : MonoBehaviour, IPickupButtonAction {

    public GameObject playerFlashLight;

    private void Start() {
        GetComponent<PickupButtonActivateController>().buttonAction = this;
    }

    public void Pickup() {
        playerFlashLight.SetActive(true);
        PickupButtonController.PickupButtonCtrl.DeactivateAndSetNoneMethodToButton();
        Destroy(gameObject);
    }
}
