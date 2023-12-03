using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;
    public AnimationCurve curve;
    [SerializeField] private float duration = 1;
    [SerializeField] private float maxHeightY = 3;
    public IEnumerator Curve(Vector3 start, Vector3 end)
    {
        var timePast = 0f;
        while (timePast < duration)
        {
            timePast += Time.deltaTime;

            var linearTime = timePast / duration;
            var heightTime = curve.Evaluate(linearTime);
            var height = Mathf.Lerp(0, maxHeightY, heightTime);
            transform.position = Vector3.Lerp(start, end, linearTime) + new Vector3(0, height, 0); //adding values on y axis
            if (transform.position == end)
            {
                Destroy(this.gameObject);
            }
            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.character.transform;
        StartCoroutine(Curve(transform.position, target.position));
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bolachito>() != null)
        {
            collision.GetComponent<Bolachito>().TakeDamage(5);
            Destroy(this.gameObject);
        }
    }
}
