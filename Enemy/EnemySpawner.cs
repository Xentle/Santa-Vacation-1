using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public Enemy_basic enemyPrefab1;
    public Enemy_tracker enemyPrefab2;
    public Enemy_sky enemyPrefab3;
    public Enemy_ranged enemyPrefab4;
    public Transform[] spawnPoints;
    private Vector3 randomPosition;
    public float mapSize;
    float level = 2, deltatime;
    public float leveltime;
    // private List<Enemy> enemies = new List<Enemy>();

    public float waitTime;
    private float timer = 0;

    private void Awake()
    {
        randomPosition = Utility.GetRandomPointOnNavMesh(
        Vector3.zero, 20f, NavMesh.AllAreas);
    }

    void Update()
    {
        timer += Time.deltaTime;
        deltatime += Time.deltaTime;

        if (timer > leveltime)
        {
            leveltime += leveltime;
            level += 1;
            waitTime *= 0.5f;
        }

        if (deltatime > waitTime)
        {
            CreateEnemy();
            deltatime = 0;
        }
    }

    private void CreateEnemy()
    {
        float x, z;
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        int random = (int)Random.Range(2, level);
        x = Random.Range(mapSize, -mapSize);
        z = Random.Range(1.0f, -1.0f);
        if (z > 0)
            z = 1.0f;
        else
            z = -1.0f;

        if (random == 2)
        {
            Enemy_basic enemy3 = Instantiate(enemyPrefab1, new Vector3(x, 0.5f, z * Mathf.Sqrt(Mathf.Pow(mapSize, 2.0f) - Mathf.Pow(x, 2.0f))), Quaternion.identity);
        }
        else if (random == 3)
        {
            Enemy_tracker enemy4 = Instantiate(enemyPrefab2, spawnPoint.position, Quaternion.identity);
        }
        else if (random == 4)
        {
            var skySpawn = spawnPoint.position;
            skySpawn.y = 2.8f;
            Enemy_sky enemy5 = Instantiate(enemyPrefab3, new Vector3(x, 2.8f, z * Mathf.Sqrt(Mathf.Pow(mapSize, 2.0f) - Mathf.Pow(x, 2.0f))), Quaternion.identity);
        }
        else if (random == 5)
        {
            Enemy_ranged enemy6 = Instantiate(enemyPrefab4, new Vector3(x, 0.5f, z * Mathf.Sqrt(Mathf.Pow(mapSize, 2.0f) - Mathf.Pow(x, 2.0f))), Quaternion.identity);
        }
    }
}