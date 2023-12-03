using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleTights : Enemy
{
    private float timer;
    [SerializeField] private float controlTime;
    [SerializeField] private GameObject missile;
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
                    GameObject pool = Instantiate(missile, transform.position, transform.rotation);
                    
                    timer = 0;
                }
                timer += Time.fixedDeltaTime;
            }
        }
    }
    public Transform GetPlayerPosition() 
    {
        return target;
    }
}
