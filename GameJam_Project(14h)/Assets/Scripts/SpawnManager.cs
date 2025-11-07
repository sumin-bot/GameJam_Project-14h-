using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    #region singleton
    public static SpawnManager Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;

    [SerializeField]
    Vector3[] spawnpoint;

    bool flag = true;
    bool isSpawn = false;

    public int turn = 0;

    void Update()
    {
        if (GameManager.Instance.isTurn && flag)
        {
            turn++;
            SpawnEnemy();
            flag = false;
            isSpawn = false;
        }

        if (!GameManager.Instance.isTurn)
        {
            flag = true;
        }
    }

    void SpawnEnemy()
    {
        if (turn % 30 == 0 && !isSpawn)
        {
            Instantiate(enemy3, spawnpoint[Random.Range(1, spawnpoint.Length - 1)] + Vector3.up, Quaternion.Euler(Vector3.up));
            isSpawn = true;
        }
        else if (turn % 10 == 0 && !isSpawn)
        {
            Instantiate(enemy2, spawnpoint[Random.Range(0, spawnpoint.Length)], Quaternion.Euler(Vector3.up));
            isSpawn = true;
        }
        else if (turn % 5 == 0 && !isSpawn)
        {
            Instantiate(enemy, spawnpoint[Random.Range(0, spawnpoint.Length)], Quaternion.Euler(Vector3.up));
            isSpawn = true;
        }
    }
}
