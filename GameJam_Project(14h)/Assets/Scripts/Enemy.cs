using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    enum Direction {up, down, right, left}

    Direction direction;

    bool isEnemyMove = false;

    float cooltime_timer = 0;

    Vector3 targetposition;

    void Awake()
    {
        targetposition = transform.position + transform.up;
    }

    void Update()
    {
        if (isEnemyMove)
        {
            Move();

            cooltime_timer += Time.deltaTime;

            if (cooltime_timer >= 0.5f)
            {
                isEnemyMove = false;
                Turn();
                cooltime_timer = 0;
            }
        }
        else
        {
            if (!GameManager.isTurn) isEnemyMove = true; // isTurn 비활성화가 Player.cs에서 적용되므로 코드 실행 전 비활성화 방지
        }
    }

    // 적 움직임
    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, targetposition, Time.deltaTime * 10f);
    }

    // 적 회전
    void Turn()
    {
        direction = (Direction)Random.Range(0, 4);

        switch (direction)
        {
            case Direction.up:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.down:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case Direction.right:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case Direction.left:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }

        // targetposition 초기화
        targetposition = transform.position + transform.up;
    }
}
