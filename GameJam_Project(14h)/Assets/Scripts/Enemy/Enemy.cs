using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    protected enum Direction {up, down, right, left}

    protected Direction direction;

    protected bool isEnemyMove = false;

    protected float PosX; // -3.5 ~ 3.5
    protected float PosY; // -3.5 ~ 3.5

    protected float cooltime_timer = 0;

    protected Vector3 targetposition;

    virtual protected void Awake()
    {

        PosX = transform.position.x;
        PosY = transform.position.y;
        direction = Direction.up;
    }

    protected void Update()
    {
        if (GameManager.Instance.isGame)
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
                if (!GameManager.Instance.isTurn) isEnemyMove = true;
            }
        }
    }

    // 적 움직임
    protected void Move()
    {
        transform.position = Vector3.Lerp(transform.position, targetposition, Time.deltaTime * 10f);
    }

    // 적 회전
    virtual protected void Turn()
    {
        int tryCount = 0;
        bool found = false;

        // 갈려는 칸이 비어있는지 확인
        while (!found && tryCount < 10)
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

            // 갈려는 칸이 맵 밖에 있는 경우 확인
            if (nextPos.x > 3.5f || nextPos.x < -3.5f || nextPos.y > 3.5f || nextPos.y < -3.5f)
            {
                tryCount++;
                continue;
            }

            // 갈려는 칸에 적이 있는 경우 확인 (현재 작동 안함)
            bool isOccupied = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject e in enemies)
            {
                if (e == null || e == this.gameObject) continue;

                if (Vector3.Distance(e.transform.position, nextPos) < 0.1f)
                {
                    isOccupied = true;
                    break;
                }
            }

            if (!isOccupied)
            {
                targetposition = nextPos;
                found = true;
            }
            else
            {
                tryCount++;
            }

            if (!found)
            {
                targetposition = transform.position;
            }
        }
    }
}
