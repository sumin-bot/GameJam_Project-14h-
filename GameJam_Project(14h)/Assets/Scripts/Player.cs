using UnityEngine;

public class Player : MonoBehaviour
{
    public float PosX; // -3.5 ~ 3.5
    public float PosY; // -3.5 ~ 3.5

    float cooltime_timer = 0;

    Vector3 targetposition;

    void Awake()
    {
        PosX = this.transform.position.x;
        PosY = this.transform.position.y;
    }

    void Update()
    {
        Move();
    }

    public void MoveStart(Vector3 direction)
    {
        GameManager.isTurn = false;
        targetposition = this.transform.position + direction;
    }

    private void Move()
    {
        if (!GameManager.isTurn)
        {

            this.transform.position = Vector3.Lerp(this.transform.position, targetposition, Time.deltaTime * 10f);

            cooltime_timer += Time.deltaTime;

            if (cooltime_timer >= 0.5f)
            {
                GameManager.isTurn = true;
                cooltime_timer = 0;
                this.transform.position = new Vector3(PosX, PosY, 0);
            }
        }

    }
}
