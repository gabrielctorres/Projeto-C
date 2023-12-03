using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entities
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float stopDistance;

    protected float playerDistance;
    protected Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
