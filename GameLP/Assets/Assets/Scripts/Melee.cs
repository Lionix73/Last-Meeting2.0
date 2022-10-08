using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    /*
    // NOTA:
    // Este script se debe agregar a Clay
    // para que el script funcione hay que crear un objeto vacio en el objeto de clay,
    // luego es necesario arrastar ese objeto vacio slot llamado Controlador Golpe.
    public class combat : MonoBehaviour
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

            foreach (Collider2D colisionador in objetos)
            {
                if (colisionador.CompareTag("Enemy"))
                {
                    colisionador.transform.GetComponent<EnemyLvl1>().tomarDano(danoGolpe);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
        }
    }
    */
}
