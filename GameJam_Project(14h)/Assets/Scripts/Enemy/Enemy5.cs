using UnityEngine;

public class Enemy5 : MonoBehaviour
{
    bool isEnemyMove = false;

    float cooltime_timer = 0;

    void Awake()
    {
        GameManager.Instance.RegisterPosition(transform.position);
    }

    private void Update()
    {
        if (GameManager.Instance.isGame)
        {
            if (isEnemyMove)
            {
                cooltime_timer += Time.deltaTime;

                if (cooltime_timer >= 0.75f)
                {
                    isEnemyMove = false;

                    GameManager.Instance.RegisterPosition(transform.position);

                    cooltime_timer = 0;
                }
            }
            else
            {
                if (!GameManager.Instance.isTurn)
                {
                    isEnemyMove = true;
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
