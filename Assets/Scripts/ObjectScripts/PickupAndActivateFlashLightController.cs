using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndActivateFlashLightController : PickupButtonDisableAction, IPickupButtonAction {

    public GameObject playerFlashLight;    

    public void Pickup() {
        playerFlashLight.SetActive(true);
        Destroy(gameObject);
        OnDisableButtonAction();
    }
}
