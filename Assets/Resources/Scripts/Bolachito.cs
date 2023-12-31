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
    [SerializeField] private Image timerImage;
    [SerializeField] private TextMeshProUGUI lifeText;

    [Header("Atributo Personagem")]
    [SerializeField] private Attribute specialAttack;
    private float horizontal;
    private float vertical;

    public GameObject specialPrefab;
    private bool canUseSkill = false;
    private float timer = 10f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        specialAttack.CalculateModifer();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimento
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        lifeImage.fillAmount = (life / lifeMax.valueTotal);
        lifeText.text = life + "/" + lifeMax.valueTotal;

        timerImage.fillAmount = (timer / 10);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            canUseSkill = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && canUseSkill)
        {
            GameObject bomba = Instantiate(specialPrefab, transform.position, Quaternion.identity);
            canUseSkill = false;
            timer = 10;
        }

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
