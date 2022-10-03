using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    CountdownTimer Timer;
    public GameStates GameState;
    private GameObject player;
    
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Canvas").GetComponent<CountdownTimer>();
        GameState = GameStates.PotionState;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void changeState()
    {
        switch(GameState){
            case GameStates.PotionState:
                AudioManager.instance.Play("Transition to Potion");
                GameState = GameStates.PlatformState;
                break;
            case GameStates.PlatformState:
                AudioManager.instance.Play("Transition to Gameplay");
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