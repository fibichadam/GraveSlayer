using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float waitTime = 10f;

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
                NavMeshHit hit;
                NavMesh.SamplePosition(child.transform.position, out hit, 50, 1);
                Instantiate(enemy, hit.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(waitTime);

            totalSpawns++;

            if(totalSpawns % 15 == 0 && waitTime > 0.5f)
            {
                waitTime -= 0.25f;
            }
        }
    }
}
