using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float enemyInterval = 3.5f;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float offset = 10f;
    public Player player;

    private Coroutine spawnCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        if (MenuMgr.Instance.CurrentMenuType == MenuType.InGameMenu)
        {
            StartSpawning();
        }
    }
    public void StartSpawning()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
        }
    }
    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }


    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        while (true) // This loop should keep running
        {
            yield return new WaitForSeconds(interval);
            GameObject enemyObj = Instantiate(enemyPrefab);
            enemyObj.transform.position = spawnPoint.position;
        }
    }
    private void LateUpdate()
    {
        // Update the spawn point's position based on the player's position
        spawnPoint.position = new Vector3(spawnPoint.position.x, player.transform.position.y + offset, spawnPoint.position.z);
    }
    private void GameOver()
    {
        // Stop spawning enemies
        StopSpawning();

        // Show the Game Over screen
        MenuMgr.Instance.ShowGameOverMenu();
    }
}