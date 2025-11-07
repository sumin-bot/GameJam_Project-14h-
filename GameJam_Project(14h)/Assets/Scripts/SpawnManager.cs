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

    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    bool flag = true;
    bool isSpawn = false;

    public int turn = 0;

    int spawn1 = 0;
    int spawn2 = 0;
    int spawn3 = 0;
    int spawn4 = 0;

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

        if (turn % 30 == 0 && !isSpawn && spawn3 < 2)
        {
            Instantiate(enemy3, spawnPosition + Vector3.up, Quaternion.Euler(Vector3.up));
            isSpawn = true;
            spawn1++;
        }
        else if (turn % 15 == 0 && !isSpawn && spawn4 < 3)
        {
            Instantiate(enemy4, spawnPosition, Quaternion.Euler(Vector3.up));
            isSpawn = true;
            spawn4++;
        }
        else if (turn % 10 == 0 && !isSpawn && spawn2 < 5)
        {
            Instantiate(enemy2, spawnPosition, Quaternion.Euler(Vector3.up));
            isSpawn = true;
        }
        else if ((turn % 5 == 0 || turn == 1) && !isSpawn && spawn1 < 7)
        {
            Instantiate(enemy, spawnPosition, Quaternion.Euler(Vector3.up));
            isSpawn = true;
        }
    }

    // 초기화
    public void Initialize()
    {
        flag = true;
        isSpawn = false;

        turn = 0;

        spawn1 = 0;
        spawn2 = 0;
        spawn3 = 0;
        spawn4 = 0;
    }
}
