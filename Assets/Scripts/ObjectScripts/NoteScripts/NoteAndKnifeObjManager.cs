using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAndKnifeObjManager : MonoBehaviour
{
    public GameObject Note;
    public GameObject Knife;
    [HideInInspector] public bool IsActivated;

    public void Activate() {
        IsActivated = true;
        Note.SetActive(true);
        Knife.SetActive(true);
    }
}
