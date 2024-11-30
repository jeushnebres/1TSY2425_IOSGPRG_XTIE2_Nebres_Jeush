using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{

    public string sceneName;


    public void ExitGame() 
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
