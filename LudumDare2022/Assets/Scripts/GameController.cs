using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    CountdownTimer Timer;
    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Canvas").GetComponent<CountdownTimer>();
        gameState = GameState.PotionState;
    }
    public void changeState()
    {
        switch(gameState){
            case GameState.PotionState:
                gameState = GameState.PlatformState;
                break;
            case GameState.PlatformState:
                gameState = GameState.PotionState;
                break;
        }
    }
    private enum GameState{
        PotionState,
        PlatformState
    }
}
