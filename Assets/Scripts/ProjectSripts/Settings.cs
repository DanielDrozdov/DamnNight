using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private void Awake() {
        Camera.main.opaqueSortMode = UnityEngine.Rendering.OpaqueSortMode.NoDistanceSort;
    }
}
