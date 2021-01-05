using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LevelPasswordController : MonoBehaviour
{   
    public static int password { get; private set; }
    private static bool IsFullPassword;
    private int _passwordLength;
    private static int _collectedNotesCount;
    private static int _numberCountInNote = 2;

    private void Start() {
        _passwordLength = _numberCountInNote * NoteSpawnController.GetNoteCount();
        password = GeneratePassword();
        UIPasswordController.GetUIPasswordController().UpdateUIPassword(password, _collectedNotesCount, _numberCountInNote);
    }

    public static void AddOneNote() {
        _collectedNotesCount++;
        if(_collectedNotesCount == 3) {
            IsFullPassword = true;
        }
        UIPasswordController.GetUIPasswordController().UpdateUIPassword(password,_collectedNotesCount,_numberCountInNote);
    }

    private int GeneratePassword() {
        StringBuilder stringBuilder = new StringBuilder();
        for(int i = 0; i < _passwordLength; i++) {
            int rnd = UnityEngine.Random.Range(0, 10);
            stringBuilder.Append(rnd);
        }
        return Convert.ToInt32(stringBuilder.ToString());
    }

    public static bool GetIsFullPassword() {
        return IsFullPassword;
    }
}
