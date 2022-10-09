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
        // cuando se presione el espacio se ejecutara la funcion de Golpe
        if (Input.GetButtonDown("Jump"))
        {
            Golpe();
        }
    }

    // accion a realizar cuando se oprima el boton de golpear
    private void Golpe()
    {
        Debug.Log("atacando");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        // Enviar informacion del dano al enemigo
        /*foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<Enemy>().tomarDano(danoGolpe);
            }
        }*/
    }

    // muestra el circulo de accion del golpe de Clay
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
