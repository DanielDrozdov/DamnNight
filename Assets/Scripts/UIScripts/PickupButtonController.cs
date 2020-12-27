using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupButtonController : MonoBehaviour {
    public GameObject PickupButton;
    private Button _pickupButtonComp;
    private IPickupButtonAction _pickupButtonAction;

    public static PickupButtonController PickupButtonCtrl { get; private set; }

    private PickupButtonController() {
    }

    void Start() {
        PickupButtonCtrl = this;
        _pickupButtonComp = PickupButton.GetComponent<Button>();
    }

    public void ActivateAndSetMethodToButton(IPickupButtonAction pickupButtonAction) {
        _pickupButtonAction = pickupButtonAction;
        _pickupButtonComp.onClick.AddListener(_pickupButtonAction.Pickup);
        PickupButton.SetActive(true);
    }

    public void DeactivateAndSetNoneMethodToButton() {
        _pickupButtonComp.onClick.RemoveListener(_pickupButtonAction.Pickup);
        PickupButton.SetActive(false);
    }
}
