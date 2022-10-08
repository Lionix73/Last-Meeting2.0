using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLvl1 : MonoBehaviour
{
    Vector2 EnemyPosition;

    public GameObject PlayerMovement;

    public float health;
    public float maxHealth;

    bool chasePlayer;
    public float velocity;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (chasePlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, EnemyPosition, velocity * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, EnemyPosition) > 12)
        {
            chasePlayer = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            EnemyPosition = PlayerMovement.transform.position;
            chasePlayer = true;
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
        CheckDeath();
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
            Destroy(gameObject);
        }
    }
}
