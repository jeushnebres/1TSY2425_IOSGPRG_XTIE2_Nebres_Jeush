using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Player _player;
    public Player Player { get { return _player; }set { _player = value; } }

    public void StartGame()
    {
        MenuMgr.Instance.ChangeMenu((int)MenuType.InGameMenu);
        Player.PlayerStart();
        SpawnerController.Instance.GameStart();
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StartSpawning(); // Start spawning enemies
        }
    }

    public void RestartGame()
    {
        Player.Reset();
        SpawnerController.Instance.Reset();
		SpawnerController.Instance.GameStart();
		Time.timeScale = 1.0f;
		MenuMgr.Instance.ChangeMenu((int)MenuType.InGameMenu);
	}

    public void GameOver()
    {
        // Call the MenuMgr to show the Game Over menu
        MenuMgr.Instance.ShowGameOverMenu();
        Debug.Log("GameManager: Game Over called");
    }

    public void MainMenu()
	{
		SpawnerController.Instance.Reset();
		Time.timeScale = 1.0f;
		MenuMgr.Instance.ChangeMenu((int)MenuType.MainMenu);
	}


}
