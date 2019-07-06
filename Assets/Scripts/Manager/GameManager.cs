using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager> {
    public enum GameState{
        TITLE,
        GAME,
        RESULT
    }
    public GameState currentGameState;

    private float playTimer;
    [HideInInspector] public float clearTime;

    private void Start(){
        SetCurrentState(GameState.TITLE);
    }

    private void Update(){
        if(currentGameState == GameState.GAME) playTimer += Time.deltaTime;
    }

    public void SetCurrentState(GameState state){
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    private void OnGameStateChanged(GameState state){
        switch(state){
            case GameState.GAME:
                break;
            case GameState.RESULT:
                clearTime = playTimer;
                break;
            case GameState.TITLE:
                playTimer = 0;
                AudioManager.Instance.PlayBGM("guutara");
                break;
            default:
                break;
        }
    }

}