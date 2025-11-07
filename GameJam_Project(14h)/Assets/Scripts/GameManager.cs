using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager Instance;

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

    public List<Vector3> nextOccupiedPositions = new List<Vector3>();

    public bool IsPositionOccupied(Vector3 pos)
    {
        pos.z = 0;
        return nextOccupiedPositions.Contains(pos);
    }

    public void RegisterPosition(Vector3 pos)
    {
        pos.z = 0;
        nextOccupiedPositions.Add(pos);
    }

    public void ClearPosition()
    {
        nextOccupiedPositions.Clear();
    }


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

                ClearPosition();
                cooltime_timer = 0;
            }
        }
    }

    // 플레이어 죽음 확인
    void CheckDeath()
    {
        if (player.hp <= 0)
        {
            isTurn = false;
            isGame = false;
        }
    }

    // 초기화
    public void Initialize()
    {
        ClearPosition();
        cooltime_timer = 0;

        player.hp = 3;
        player.transform.position = new Vector3(0.5f, 0.5f, 0); 

        isGame = true;
        isTurn = true;
    }
}
