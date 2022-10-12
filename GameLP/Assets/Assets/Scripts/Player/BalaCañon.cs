using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaCañon : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            if (collision.GetComponent<EnemyReciebeDamage>() != null)
            {
                collision.GetComponent<EnemyReciebeDamage>().DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
