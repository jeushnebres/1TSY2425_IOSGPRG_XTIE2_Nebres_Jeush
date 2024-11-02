using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : Singleton<SpawnerController>
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;

    [SerializeField] List<GameObject> enemyList = new List<GameObject>();

    Coroutine spawningRoutine;
    private bool isSpawning = false;

    public void GameStart()
    {
      
        spawningRoutine = StartCoroutine(StartSpawn());
    }
    private void Awake()
    {
        Debug.Log("SpawnerController: Awake() called");
    }

    public static void CreateInstance()
    {
        if (Instance == null)
        {
 
        }
    }

    IEnumerator StartSpawn()
    {
      
        while (GameManager.Instance.Player.IsAlive)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);
        }
    }

    public void StopSpawn()
    {
		StopCoroutine(spawningRoutine);
        isSpawning = false;
    }

    void SpawnEnemy()
    {
        Debug.Log("SpawnerController: SpawnEnemy() called");
        GameObject enemyObj = (GameObject)Instantiate(enemyPrefab);
        enemyObj.transform.position = spawnPoint.position;
        enemyList.Add(enemyObj);
    }

    public void RemoveEnemy(GameObject enemyObj)
    {
        enemyList.Remove(enemyObj);
        Destroy(enemyObj);
    }

	public void Reset()
	{
		foreach(GameObject enemyObj in enemyList)
        {
            Destroy(enemyObj);
        }
        enemyList.Clear();
	}
}
