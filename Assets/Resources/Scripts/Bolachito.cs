using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bolachito : Entities
{
    [SerializeField] private Attribute specialAttack;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        lifeMax.CalculateModifer();
        life = lifeMax.valueTotal;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimento
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.T))
        {
            GameManager.instance.AddExperience(10);
        }

    }

    void FixedUpdate()
    {
        //Movimento
        Vector2 direction = new Vector2(horizontal, vertical);
        rb.velocity = direction * Time.fixedDeltaTime * spd * 10;
        SetDirectionSprite(direction);
    }



}
