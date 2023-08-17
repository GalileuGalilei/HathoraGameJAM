using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyObj;

    private float enemySpawnTimer = .0f;
    [SerializeField] private float timeToSpawn = 4f;
    // Update is called once per frame
    void Update()
    {
        if (enemySpawnTimer > timeToSpawn)
        {
            enemyObj.transform.position = transform.position;
            Instantiate(enemyObj);
            enemySpawnTimer = 0f;
        }
        enemySpawnTimer += Time.deltaTime;
    }
}
