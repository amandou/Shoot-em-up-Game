using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float minStartWait = 5;
    [SerializeField] private float maxStartWait = 10;
    [SerializeField] private float spawnWait = 4;
    [SerializeField] private float numberEnemies = 1;
    [SerializeField] private float maxNumberEnemies = 2;

    public GameObject enemyPrefab;

    void Start()
    { 
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        // TODO: Verify if the player is null or dead to stop waves
        yield return new WaitForSeconds(Random.Range(minStartWait, maxStartWait));
        for (int i = 0; i < numberEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-transform.position.x, transform.position.x), Random.Range(-transform.position.y, transform.position.y), transform.position.z);
            var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        numberEnemies++;
        if (numberEnemies > maxNumberEnemies)
        {
            numberEnemies = Random.Range(0, maxNumberEnemies);
        }
        yield return new WaitForSeconds(Random.Range(spawnWait, spawnWait+4));
        StartCoroutine(SpawnEnemy());
    }
}
