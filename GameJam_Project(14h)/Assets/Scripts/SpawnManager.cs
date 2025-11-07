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

    public Player player;

    public GameObject[] enemy;

    bool flag = true;
    bool isSpawn = false;

    public int turn = 0;

    int[] spawn = new int[5]{0, 0, 0, 0, 0};

    public int enemyNumber = 0;

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

    // 적 소환
    void SpawnEnemy()
    {
        Vector3 spawnPosition = GameManager.Instance.FindRandomPosition();

        if (turn % 30 == 0 && !isSpawn && spawn[2] < 2)
        {
            Instantiate(enemy[2], spawnPosition + Vector3.up, Quaternion.Euler(Vector3.up));
            isSpawn = true;
            spawn[3]++;
            enemyNumber++;
        }
        else if (turn % 15 == 0 && !isSpawn && spawn[3] < 5)
        {
            Instantiate(enemy[3], spawnPosition, Quaternion.Euler(Vector3.up));
            isSpawn = true;
            spawn[3]++;
            enemyNumber++;
        }
        else if (turn % 12 == 0 && !isSpawn && spawn[4] < 3)
        {
            Instantiate(enemy[4], spawnPosition, Quaternion.Euler(Vector3.up));
            isSpawn = true;
            spawn[4]++;
            enemyNumber++;
        }
        else if (turn % 9 == 0 && !isSpawn && spawn[1] < 7)
        {
            Instantiate(enemy[1], spawnPosition, Quaternion.Euler(Vector3.up));
            isSpawn = true;
            spawn[1]++;
            enemyNumber++;
        }
        else if ((turn % 3 == 0 || turn == 1) && !isSpawn && spawn[0] < 10)
        {
            Instantiate(enemy[0], spawnPosition, Quaternion.Euler(Vector3.up));
            isSpawn = true;
            spawn[0]++;
            enemyNumber++;
        }
    }

    // 초기화
    public void Initialize()
    {
        flag = true;
        isSpawn = false;

        turn = 0;

        for (int i = 0; i < 5; i++)
        {
            spawn[i] = 0;
        }

        enemyNumber = 0;
    }
}
