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
        VerifyDeath();
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
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            this.TakeDamage(GameManager.instance.weakAttack.valueTotal);
        }
        if (other.GetComponent<Bolachito>() != null)
        {
            other.GetComponent<Bolachito>().TakeDamage(weakAttack.valueTotal);
            anim.SetBool("atacou", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Bolachito>() != null)
        {
            anim.SetBool("atacou", false);
        }
    }

}
