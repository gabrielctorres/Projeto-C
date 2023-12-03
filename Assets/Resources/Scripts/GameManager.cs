using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour
{
    private float currentLevel = 1;
    private float experience;

    public Bolachito character;
    public Attribute lifeCharacter;
    public Attribute weakAttack;
    public Attribute specialAttack;
    [SerializeField] private Image levelImage;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private GameObject menuLevelUP;
    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        levelImage.fillAmount = (experience / 100);
        levelText.text = "LEVEL " + currentLevel.ToString();

    }

    public void openLevelUp()
    {
        menuLevelUP.SetActive(true);
    }
    public void AddExperience(float xp)
    {
        if (experience < 100)
        {
            experience += xp;
        }
        else if (experience >= 100)
        {
            experience = 0;
            currentLevel++;
            if (currentLevel % 5 == 0)
            {
                openLevelUp();
            }
        }

    }

    public void UpgradeLife()
    {
        menuLevelUP.SetActive(false);
        lifeCharacter.AddModifier(10f);
        lifeCharacter.CalculateModifer();
        character.HealDamage(lifeCharacter.valueTotal, true);
    }

    public void UpgradeWeakAttack()
    {
        menuLevelUP.SetActive(false);
        weakAttack.AddModifier(3f);
        weakAttack.CalculateModifer();
        character.HealDamage(lifeCharacter.valueTotal, true);
    }

    public void UpgradeSpecial()
    {
        menuLevelUP.SetActive(false);
        specialAttack.AddModifier(3f);
        specialAttack.CalculateModifer();
        character.HealDamage(lifeCharacter.valueTotal, true);
    }
}
