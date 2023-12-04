using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombadeiro : MonoBehaviour
{
    private float timer = 10f;
    Collider2D[] inExoplodeRadius = null;
    ParticleSystem effect;

    [SerializeField] private float explosionForceMulti;
    [SerializeField] private float explosionRadius;

    private bool canExplode = false;
    void Start()
    {
        InvokeRepeating("Test", 1, 1f);

        effect = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            canExplode = true;
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        if (canExplode)
        {
            Explosao();
        }
    }
    public void Explosao()
    {
        inExoplodeRadius = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D o in inExoplodeRadius)
        {
            Rigidbody2D rb2d = o.GetComponent<Rigidbody2D>();
            Enemy enemy = o.GetComponent<Enemy>();
            if (rb2d != null && enemy != null)
            {
                Debug.Log(o.gameObject.name);
                Vector2 distanceVector = o.transform.position - transform.position;
                if (distanceVector.magnitude > 0)
                {
                    Debug.Log("boommm");
                    float explosionForce = explosionForceMulti / distanceVector.magnitude;
                    rb2d.AddForce(distanceVector.normalized * explosionForce);
                    enemy.TakeDamage(GameManager.instance.specialAttack.valueTotal);
                }
            }
        }
        effect.Play();
        canExplode = false;
        Destroy(this.gameObject, 1f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    public void Test()
    {
        StartCoroutine(ExplosionAnimation());
    }
    public IEnumerator ExplosionAnimation()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        yield return new WaitForSeconds(0.2f);
        transform.localScale = new Vector3(1f, 1, 1);
    }
}
