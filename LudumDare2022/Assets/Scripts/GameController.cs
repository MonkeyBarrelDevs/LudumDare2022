using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    CountdownTimer Timer;
    public GameStates GameState;
    
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Canvas").GetComponent<CountdownTimer>();
        GameState = GameStates.PotionState;
    }
    public void changeState()
    {
        switch(GameState){
            case GameStates.PotionState:
                GameState = GameStates.PlatformState;
                break;
            case GameStates.PlatformState:
                SceneController.instance.FadeToLevel(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }
    
}
public enum GameStates
    {
        PotionState,
        PlatformState
    }