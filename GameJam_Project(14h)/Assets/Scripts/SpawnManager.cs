using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject enemy;
    public GameObject bigenemy;

    [SerializeField]
    Vector3[] spawnpoint;

    bool flag = true;
    bool isSpawn = false;

    public int turn = 0;

    void Update()
    {
        if (GameManager.isTurn && flag)
        {
            turn++;
            SpawnEnemy();
            flag = false;
            isSpawn = false;
        }

        if (!GameManager.isTurn)
        {
            flag = true;
        }
    }

    void SpawnEnemy()
    {
        if (turn % 30 == 0 && !isSpawn)
        {
            Instantiate(bigenemy, spawnpoint[Random.Range(0, spawnpoint.Length)], Quaternion.Euler(Vector3.up));
            isSpawn = true;
        }
        else if (turn % 3 == 0 && !isSpawn)
        {
            Instantiate(enemy, spawnpoint[Random.Range(0, spawnpoint.Length)], Quaternion.Euler(Vector3.up));
            isSpawn = true;
        }
    }
}
