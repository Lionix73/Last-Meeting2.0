using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;

    [SerializeField] private float radioGolpe;

    [SerializeField] private float danoGolpe;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Golpe();
        }
    }

    private void Golpe()
    {
        Debug.Log("atacando");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach(Collider2D collider in objetos)
        {
            if(collider.CompareTag("Enemy")) 
            {
                Debug.Log("atacando a un enemigo");
                collider.transform.GetComponent<EnemyReciebeDamage>().DealDamage(danoGolpe);
            }
        }        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
