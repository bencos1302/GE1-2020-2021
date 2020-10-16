using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public float radius = 10;
    public float spawnHeight = 5;
    public int spawnRate = 1;
    public int max = 5;

    public GameObject enemyPrefab;
    public float enemyScale = 2.0f;

    void Spawn()
    {
        GameObject enemy = GameObject.Instantiate(enemyPrefab);
        enemy.transform.localScale = new Vector3(enemyScale, enemyScale, enemyScale);

        Vector3 pos = new Vector3(Random.Range(-radius, radius), spawnHeight, Random.Range(-radius, radius));

        enemy.transform.position = transform.TransformPoint(pos);

        enemy.transform.parent = this.transform;
        enemy.tag = "Enemy";
    }

    void OnEnable()
    {
        StartCoroutine(SpawnCoroutine());
    }

    System.Collections.IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            GameObject[] enemies =
                GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length < max)
            {
                Spawn();
            }
            yield return new WaitForSeconds(1.0f / (float)spawnRate); 
        }
    }
}
