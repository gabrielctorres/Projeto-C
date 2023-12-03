using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    private Vector3 dragStartPos;
    private float power = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameManager.instance.character.transform;
        dragStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce();
        //Parabula();
    }

    public static Vector2 Parabola(Vector2 start, Vector2 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;
        var mid = Vector2.Lerp(start, end, t);
        return new Vector2(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t));
    }

    public void Parabula() 
    {
        Vector2 velocity = (target.position - dragStartPos) * power;
        rb.velocity = velocity;
    }
}
