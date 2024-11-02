using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuType
{
    MainMenu        = 0,
    InGameMenu      = 1,
    GameOverMenu    = 2,
}

public class MenuMgr : Singleton<MenuMgr>
{
    public GameObject[] menuList;
    public MenuType CurrentMenuType { get; private set; }

    private void Start()
    {
        ChangeMenu((int)MenuType.MainMenu);
    }

    public void ChangeMenu(int index)
    {
        foreach (GameObject menu in menuList)
        {
            menu.SetActive(false);
        }
        menuList[index].SetActive(true);
        CurrentMenuType = (MenuType)index;
    }

    public void StartGame()
    {
        SpawnerController.Instance.GameStart();
        GameManager.Instance.StartGame();
    }
    public void ShowGameOverMenu()
    {
        ChangeMenu((int)MenuType.GameOverMenu);
        Time.timeScale = 0; // Pause the game
        Debug.Log("Game Over Menu Displayed");
    }
    public void RetryGame()
    {


        // Start the game
        StartGame();

        // Show the in-game menu
        ChangeMenu((int)MenuType.InGameMenu);
        Time.timeScale = 1; // Resume the game
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

}