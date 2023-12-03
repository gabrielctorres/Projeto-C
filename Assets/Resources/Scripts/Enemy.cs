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
        target = GameObject.Find("Personagem_Bolachito").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
        playerDistance = (target.position - transform.position).magnitude;
    }
}
