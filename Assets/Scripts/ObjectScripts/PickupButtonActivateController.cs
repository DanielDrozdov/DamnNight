using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupButtonActivateController : MonoBehaviour
{
    public IPickupButtonAction buttonAction;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            PickupButtonController.PickupButtonCtrl.ActivateAndSetMethodToButton(buttonAction);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            PickupButtonController.PickupButtonCtrl.DeactivateAndSetNoneMethodToButton();
        }
    }
}

public interface IPickupButtonAction {
     void Pickup();
}
