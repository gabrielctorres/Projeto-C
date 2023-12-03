using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleTights : Enemy
{
    private float timer;
    [SerializeField] private float controlTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Personagem_Bolachito").transform;
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
                if(timer > controlTime)
                {
                    //Invocar ataque
                    //GameObject pool = Instantiate(cheesePool, transform.position, transform.rotation);
                    //pool.GetComponent<CheesePool>().damage = attackDamage;
                    timer = 0;
                }
                timer += Time.fixedDeltaTime;
            }
        }
    }
}
