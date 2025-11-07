using UnityEngine;

public class Enemy1 : Enemy
{
    override protected void Awake()
    {

        base.Awake();

        targetposition = transform.position + transform.up;
    }

    // Àû È¸Àü
    override protected void Turn()
    {
        base.Turn();
    }
}
