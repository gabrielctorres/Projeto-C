using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBall : Enemy
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
        playerDistance = (target.position - transform.position).magnitude;
    }
    private void FixedUpdate()
    {
        if (target)
        {
            if (playerDistance > stopDistance)
            {
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * spd;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }

    }
    
}
