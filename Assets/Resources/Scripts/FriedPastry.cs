using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriedPastry : Enemy
{
    private Vector2 dir;
    public Transform Aim;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void FixedUpdate()
    {
        if (target)
        {
            dir = new Vector2(moveDirection.x, moveDirection.y);
            if (playerDistance > stopDistance)
            {
                rb.velocity = dir * spd;
                Vector3 vector3 = Vector3.left * dir.x + Vector3.down * dir.y;
                Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
            }
            else
            {
                rb.velocity = Vector3.zero;
                //Dano
                
            }
        }
    }
}
