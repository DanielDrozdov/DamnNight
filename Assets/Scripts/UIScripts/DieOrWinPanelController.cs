using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOrWinPanelController : MonoBehaviour
{
    [SerializeField] private GameObject DiePanel;
    [SerializeField] private GameObject WinPanel;

    public void ActivateDiePanel() {
        DiePanel.SetActive(true);
    }

    public void ActivateWinPanel() {
        WinPanel.SetActive(true);
    }
}
