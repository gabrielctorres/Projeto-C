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
    }

    // Update is called once per frame
    void Update()
    {
        //Movimento
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //Movimento
        rb.velocity = new Vector2(horizontal, vertical) * Time.fixedDeltaTime * spd * 10;
    }

    

}
