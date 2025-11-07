using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    #region singleton
    private static SpawnManager instance;
    public static SpawnManager Instance
    {
        get
        {
            if (instance == null) instance = new SpawnManager();
            return instance;
        }
    }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public GameObject enemy;
    public GameObject bigenemy;

    [SerializeField]
    Vector3[] spawnpoint;

    bool flag = true;
    bool isSpawn = false;

    public int turn = 0;

    void Update()
    {
        if (GameManager.Instance.isGame)
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
