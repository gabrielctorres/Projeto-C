using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Bolachito : Entities
{
    [Header("UI")]
    [SerializeField] private Image lifeImage;
    [SerializeField] private TextMeshProUGUI lifeText;

    [Header("Atributo Personagem")]
    [SerializeField] private Attribute specialAttack;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimento
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.T))
        {
            GameManager.instance.AddExperience(10);
            //TakeDamage(1f);
        }
        lifeImage.fillAmount = (life / lifeMax.valueTotal);
        lifeText.text = life + "/" + lifeMax.valueTotal;
    }

    void FixedUpdate()
    {
        //Movimento
        Vector2 direction = new Vector2(horizontal, vertical);
        rb.velocity = direction * Time.fixedDeltaTime * spd * 10;
        SetDirectionSprite(direction);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        specialAttack.ResetTotalValue();
    }

}
