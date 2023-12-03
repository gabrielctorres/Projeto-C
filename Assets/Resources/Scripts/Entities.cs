using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    [SerializeField] protected Attribute lifeMax;
    [SerializeField] protected float life;
    [SerializeField] protected Attribute weakAttack;
    [SerializeField] protected float spd;
    protected Rigidbody2D rb;
    protected Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public virtual void SetDirectionSprite(Vector2 direction)
    {
        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
    }
    public float SlowDown(float slow)
    {
        float aux = spd;
        spd = slow;
        return aux;
    }
    public void HealDamage(float value)
    {
        if (life < lifeMax.valueTotal)
            life += value;
    }
    public float CheckDPS()
    {
        return weakAttack.valueTotal;
    }

}
