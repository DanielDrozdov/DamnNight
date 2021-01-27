using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButtonController : MonoBehaviour
{
    private enum GameState {
        Pause,
        Play
    }

    public Image ButtonImage;
    public GameObject UIPlayerCanvas;
    public AudioListener AudioListener;
    [SerializeField] private Sprite Play;
    [SerializeField] private Sprite Stop;
    private GameState gameState = GameState.Play;

    public void OnChangeGameState() {
        if(gameState == GameState.Play) {
            ChangeState(0, GameState.Pause, Play);
        } else if(gameState == GameState.Pause) {
            ChangeState(1, GameState.Play, Stop);
        }
    }

    private void ChangeState(float timeScale,GameState gameState,Sprite sprite) {
        Time.timeScale = timeScale;
        this.gameState = gameState;
        ButtonImage.sprite = sprite;
        bool IsOffComponents = GameState.Pause == gameState ? false : true;
        AudioListener.pause = !IsOffComponents;
        UIPlayerCanvas.SetActive(IsOffComponents);
    }
}
