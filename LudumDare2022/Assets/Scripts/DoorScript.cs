using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    private int curSceneIndex;

    void Awake()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            SceneController.instance.FadeToLevel(curSceneIndex + 1);
        }
    }
}
