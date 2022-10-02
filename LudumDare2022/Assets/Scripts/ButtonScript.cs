using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private int curSceneIndex;
    
    public void Awake()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void goToNextLevel()
    {
        SceneController.instance.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
