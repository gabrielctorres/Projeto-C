using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePool : MonoBehaviour
{
    private float timer;
    [SerializeField] private float timerSet;
    public float oldSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if (timer >= timerSet) 
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().HealDamage();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bolachito>() != null) 
        {
            oldSpeed = collision.GetComponent<Bolachito>().SlowDown(5);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Bolachito>() != null) 
        {
            collision.GetComponent<Bolachito>().SlowDown(oldSpeed);
        }
    }

}
