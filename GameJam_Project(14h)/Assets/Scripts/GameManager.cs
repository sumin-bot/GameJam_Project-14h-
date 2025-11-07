using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    float horizontal;
    float vertical;

    public static bool isTurn = true;

    void Update()
    {
        MoveTrigger();
    }

    // 플레이어 움직임 조작
    void MoveTrigger()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (isTurn)
        {
            if (horizontal == 1 && player.PosX < 3.5f)
            {
                player.PosX++;
                player.MoveStart(Vector3.right);
                isTurn = false;
            }
            else if (horizontal == -1 && player.PosX > -3.5f)
            {
                player.PosX--;
                player.MoveStart(Vector3.left);
                isTurn = false;
            }

            if (vertical == 1 && player.PosY < 3.5f)
            {
                player.PosY++;
                player.MoveStart(Vector3.up);
                isTurn = false;
            }
            else if (vertical == -1 && player.PosY > -3.5f)
            {
                player.PosY--;
                player.MoveStart(Vector3.down);
                isTurn = false;
            }
        }
    }
}
