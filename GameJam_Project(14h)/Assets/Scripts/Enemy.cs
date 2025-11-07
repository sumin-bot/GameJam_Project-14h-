using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    enum Direction {up, down, right, left}

    Direction direction;

    bool isEnemyMove = false;

    float PosX; // -3.5 ~ 3.5
    float PosY; // -3.5 ~ 3.5

    float cooltime_timer = 0;

    Vector3 targetposition;

    void Awake()
    {

        PosX = transform.position.x;
        PosY = transform.position.y;
        direction = Direction.up;

        targetposition = transform.position + transform.up;
    }

    void Update()
    {
        if (isEnemyMove)
        {
            Move();

            cooltime_timer += Time.deltaTime;

            if (cooltime_timer >= 0.75f)
            {
                isEnemyMove = false;
                transform.position = targetposition;
                Turn();
                cooltime_timer = 0;
            }
        }
        else
        {
            if (!GameManager.isTurn) isEnemyMove = true;
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
        bool found = false;

        while (!found)
        {
            direction = (Direction)Random.Range(0, 4);
            Vector3 nextPos = transform.position;

            switch (direction)
            {
                case Direction.up:
                    nextPos += Vector3.up;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;

                case Direction.down:
                    nextPos += Vector3.down;
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;

                case Direction.right:
                    nextPos += Vector3.right;
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                    break;

                case Direction.left:
                    nextPos += Vector3.left;
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
            }

            if (nextPos.x > 3.5f || nextPos.x < -3.5f || nextPos.y > 3.5f || nextPos.y < -3.5f)
            {
                targetposition = transform.position;
            }
            else
            {
                targetposition = nextPos;
                found = true;
            }

        }
    }
}
