using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndActivateNoteController : PickupButtonDisableAction,IPickupButtonAction {
    public delegate void PickupNoteDelegate(Vector3 notePos);
    public static event PickupNoteDelegate OnPickupNote;

    public void Pickup() {
        LevelPasswordController.AddOneNote();
        Destroy(gameObject);
        OnDisableButtonAction();
        OnPickupNote?.Invoke(gameObject.transform.position);
    }
}
