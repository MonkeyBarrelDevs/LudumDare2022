using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] int sceneNumber;
    public void goToScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
