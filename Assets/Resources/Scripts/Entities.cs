using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    [SerializeField] protected float life;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float spd;
    [SerializeField] protected Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage) 
    {
        life-=damage;
    }
    public float SlowDown(float slow) 
    {
        float aux = spd;
        spd = slow;
        return aux;
    }
    public void HealDamage() 
    {
        life++;
    }
    public float CheckDPS() 
    {
        return attackDamage;
    }
}
