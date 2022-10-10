using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public Text healthText;
    public Slider healthSlider;

    public GameObject player;

    public float health;
    public float maxHealth;

    void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxHealth;
        healthSlider.value = 1;
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        healthSlider.value = CalculateHealthPercetage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        SetHealthUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverHeal();
        SetHealthUI();
    }

    private void CheckOverHeal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(player);
        }
    }

    float CalculateHealthPercetage()
    {
        return health / maxHealth;
    }
}
