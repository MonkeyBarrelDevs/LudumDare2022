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

    public void gameEnd()
    {
        Application.Quit();
    }

    public void goToLevel(string sceneName) 
    {
        SceneController.instance.FadeToLevel(SceneManager.GetSceneByName(sceneName).buildIndex);
    }

    public void goToLevel(int buildIndex)
    {
        SceneController.instance.FadeToLevel(buildIndex);
    }

    public void ToggleObject(GameObject obj) 
    {
        obj.SetActive(obj.activeSelf);
    }

    public void ToggleImage(Image image) 
    {
        image.enabled = !image.enabled;
    }
}
