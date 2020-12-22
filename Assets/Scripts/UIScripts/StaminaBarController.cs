using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarController : MonoBehaviour
{
    private Image StaminaBar;
    private float _kAmountPerOneStamina;

    private void Start() {
        StaminaBar = GetComponent<Image>();
        _kAmountPerOneStamina = 1 / PlayerMoveController.staminaReserv;
    }

    private void Update() {
        UpdateStaminaBar();
    }

    private void UpdateStaminaBar() {
        StaminaBar.fillAmount = _kAmountPerOneStamina * PlayerMoveController.totalStamina;
    }
}
