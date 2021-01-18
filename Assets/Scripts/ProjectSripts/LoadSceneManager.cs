using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public void LoadGame() {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadMainMenu() {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(0);
        asyncOperation.allowSceneActivation = false;
        StartCoroutine(WaitTwoSecondsCoroutine(asyncOperation));
    }

    private IEnumerator WaitTwoSecondsCoroutine(AsyncOperation asyncOperation) {
        yield return new WaitForSeconds(2);
        asyncOperation.allowSceneActivation = true;
    }
}
