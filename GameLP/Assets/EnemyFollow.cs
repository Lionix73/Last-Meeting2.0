using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Vector2 EnemyPosition;
    public GameObject PlayerMovement;
    bool chasePlayer;
    public float velocity;

    void Start()
    {

    }

    void Update()
    {
        if(chasePlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, EnemyPosition, velocity * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, EnemyPosition) > 25)
        {
            chasePlayer = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag.Equals("Player"))
        {
            EnemyPosition = PlayerMovement.transform.position;
            chasePlayer = true;
        }    
    }
}