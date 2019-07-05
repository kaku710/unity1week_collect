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
    private GameState currentGameState;

    public void SetCurrentState(GameState state){
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    private void OnGameStateChanged(GameState state){
        switch(state){
            case GameState.GAME:
                break;
            case GameState.RESULT:
                break;
            case GameState.TITLE:
                break;
            default:
                break;
        }
    }

}