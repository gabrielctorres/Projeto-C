using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] Camera mainCamera;
    private SpriteRenderer sprite;
    float fireRate = 1f;
    float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }
    private void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shootBullet = Instantiate(bullet, spawnBullet.position, transform.rotation);
            Vector3 mousePos = Input.mousePosition;
            Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(mousePos);
            Vector2 direction = (mouseWorld - transform.parent.position).normalized * 6;
            shootBullet.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
            Destroy(shootBullet, 4);
        }
    }
    private void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = mainCamera.ScreenToWorldPoint(mousePos);
        screenPoint.z = 0;
        Vector2 offSet = new Vector2(screenPoint.x - transform.position.x, screenPoint.y - transform.position.y).normalized;

        float angle = Mathf.Atan2(offSet.y, offSet.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (screenPoint.x < transform.position.x);
    }
}
