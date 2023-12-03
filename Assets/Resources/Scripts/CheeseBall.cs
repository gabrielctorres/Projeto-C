using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBall : Enemy
{
    private float timer;
    [SerializeField] private float controlTime;
    [SerializeField] private GameObject cheesePool;
    // Start is called before the first frame update
    void Start()
    {
        //controlTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (target)
        {
            if(timer > controlTime)
            {
                //Invocar ataque
                GameObject pool = Instantiate(cheesePool, transform.position, transform.rotation);
                //pool.GetComponent<CheesePool>().damage = attackDamage;
                timer = 0;
            }
            timer += Time.fixedDeltaTime;
            if (playerDistance > stopDistance)
            {
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * spd;
            }
            else
            {
                rb.velocity = Vector3.zero;
                //Explosão
            }
        }
    }
    
}
