using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float waitTime = 0.5f;

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        int totalSpawns = 0;
        while (true)
        {
            foreach (Transform child in transform)
            {
                Instantiate(enemy, child.transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(waitTime);

            totalSpawns++;

            if(totalSpawns % 10 == 0 && waitTime > 0.5f)
            {
                waitTime -= 0.25f;
            }
        }
    }
}
