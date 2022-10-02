using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;
    [SerializeField] TextMeshProUGUI countdownText;
    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.00");
        if(currentTime <= 0)
        {
            currentTime = 10f;
            GameController.instance.changeState();
        }
    }

    public float getTime()
    {
        return currentTime;
    }
}
