using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entities
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float stopDistance;

    public List<GameObject> listEnemy = new List<GameObject>();
    protected float playerDistance;
    protected Vector2 moveDirection;
    public float xp;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        target = GameObject.Find("Personagem_Bolachito").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void VerifyDeath()
    {
        if (life <= 0)
        {
            GameManager.instance.AddExperience(xp);
            listEnemy.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
    public void Movement()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
        playerDistance = (target.position - transform.position).magnitude;
    }


}
