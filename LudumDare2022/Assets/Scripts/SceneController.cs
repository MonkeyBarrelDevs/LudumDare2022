using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static event Action<string, string> OnLevelOutEvent;

    public static SceneController instance;
    public Animator animator;
    private int levelToLoad;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        Time.timeScale = 0f;
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Physics2D.gravity = Physics2D.gravity * -MathF.Sign(Physics2D.gravity.y);
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeIn");
    }

    public void onFadeInStart()
    {
    }

    public void onFadeInComplete()
    {
        Time.timeScale = 1f;
    }

    public void gameEnd()
    {
        Application.Quit();
    }

    public static string GetActiveSceneName() 
    {
        return SceneManager.GetActiveScene().name;
    }
}
