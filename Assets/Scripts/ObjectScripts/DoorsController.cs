using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorsController : MonoBehaviour
{
    public LoadSceneManager LoadSceneManager;
    public DieOrWinPanelController DieOrWinPanelController;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject PlayerCanvas;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            if(LevelPasswordController.IsFullPassword()) {
                End();
            } else {
                NotEnoughNotes();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            text.SetActive(false);
        }
    }

    private void End() {
        DieOrWinPanelController.ActivateWinPanel();
        PlayerCanvas.SetActive(false);
        LoadSceneManager.LoadMainMenu();
    }

    private void NotEnoughNotes() {
        text.SetActive(true);
    }
}
