using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Gradient colorBullet;
    // Start is called before the first frame update
    void Start()
    {
        RandomColor();
    }
    public void RandomColor()
    {
        GetComponent<SpriteRenderer>().color = colorBullet.Evaluate(Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * spd);
    }
    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entities>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}
