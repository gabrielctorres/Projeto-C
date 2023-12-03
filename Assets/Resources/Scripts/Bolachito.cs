using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolachito : Entities
{
    [SerializeField] private float luck;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        //Iniciarlizar o rb
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimento
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

    }

    void FixedUpdate()
    {
        //Movimento
        Vector2 direction = new Vector2(horizontal, vertical);
        rb.velocity = direction * Time.fixedDeltaTime * spd * 10;
        SetDirectionSprite(direction);
    }

    

}
