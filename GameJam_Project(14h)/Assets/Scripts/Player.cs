using UnityEngine;

public class Player : MonoBehaviour
{
    public float PosX; // -3.5 ~ 3.5
    public float PosY; // -3.5 ~ 3.5

    float cooltime_timer = 0;

    Vector3 targetposition;

    void Awake()
    {
        PosX = transform.position.x;
        PosY = transform.position.y;
    }

    void Update()
    {
        if (!GameManager.isTurn) Move();
    }

    // 플레이어 움직임 시작 (targetposition 초기화)
    public void MoveStart(Vector3 direction)
    {
        targetposition = transform.position + direction;
    }

    // 플레이어 움직임
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, targetposition, Time.deltaTime * 10f);

        cooltime_timer += Time.deltaTime;

        if (cooltime_timer >= 0.5f)
        {
            GameManager.isTurn = true;
            cooltime_timer = 0;
            transform.position = new Vector3(PosX, PosY, 0);
        }
    }
}
