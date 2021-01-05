using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPasswordController : MonoBehaviour
{
    private static UIPasswordController UIPasswordCntrl;
    private TextMeshProUGUI text;
    private string[] passwordParts = { "**", "**", "**" };
    private UIPasswordController() { }

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
        UIPasswordCntrl = this;
    }

    public void UpdateUIPassword(int passwordPart, int collectedNotesCount,int numberCountInNote) {
        string password = passwordPart.ToString();
        if(collectedNotesCount > 0) {
            int i = collectedNotesCount - 1;
            passwordParts[i] = password.Substring(i * numberCountInNote, numberCountInNote);      
        }
        text.text = string.Format("Password: {0} {1} {2}", passwordParts[0], passwordParts[1], passwordParts[2]);
    }

    public static UIPasswordController GetUIPasswordController() {
        return UIPasswordCntrl;
    }
}
