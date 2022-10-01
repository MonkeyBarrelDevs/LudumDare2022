using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    CountdownTimer Timer;
    bool potionState;
    bool platformState;

    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Canvas").GetComponent<CountdownTimer>();
        potionState = true;
        platformState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeState()
    {
        potionState = !potionState;
        platformState = !platformState;
    }
}
