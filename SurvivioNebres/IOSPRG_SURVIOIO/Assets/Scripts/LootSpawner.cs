using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ammoPrefabs;
    [SerializeField] private float spawnRadius = 5f; // Radius around the spawner for random spawning
    [SerializeField] private float spawnInterval = 20f; // Time interval for spawning ammo
    [SerializeField] private int ammoCount = 5; // Number of ammo items to spawn each time

    void Start()
    {
        // Start the coroutine to spawn ammo
        StartCoroutine(SpawnAmmoCoroutine());
    }

    private IEnumerator SpawnAmmoCoroutine()
    {
        while (true) // Infinite loop to keep spawning
        {
            SpawnRandomLoot(); // Spawn ammo
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
        }
    }

    private void SpawnRandomLoot()
    {
        for (int i = 0; i < ammoCount; i++) // Spawn multiple ammo items
        {
            // Check if there are any ammo prefabs
            if (ammoPrefabs.Length > 0)
            {
                int randomAmmoIndex = Random.Range(0, ammoPrefabs.Length);
                Vector2 randomPosition = GetRandomPosition();
                Instantiate(ammoPrefabs[randomAmmoIndex], randomPosition, Quaternion.identity);
            }
        }
    }

    private Vector2 GetRandomPosition()
    {
        // Generate a random position within a square area around the spawner
        float randomX = Random.Range(-spawnRadius, spawnRadius);
        float randomY = Random.Range(-spawnRadius, spawnRadius);

        Vector2 randomPosition = new Vector2(randomX, randomY) + (Vector2)transform.position;
        return randomPosition;
    }
}