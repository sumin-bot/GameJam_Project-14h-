using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();
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


    public Player player;

    float horizontal;
    float vertical;

    float cooltime_timer = 0;

    public bool isGame = true;
    public bool isTurn = true;

    void Update()
    {
        if (isGame)
        {
            MoveTrigger();
            CheckDeath();
        }
    }

    // 플레이어 움직임 조작
    void MoveTrigger()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0) vertical = 0;

        if (isTurn && !Player.isPlayerMove)
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
        else
        {
            cooltime_timer += Time.deltaTime;

            if (cooltime_timer >= 0.75f)
            {
                isTurn = true;
                cooltime_timer = 0;
            }
        }
    }

    // 플레이어 죽음 확인
    void CheckDeath()
    {
        if (player.hp <= 0)
        {
            isGame = false;
        }
    }
}
