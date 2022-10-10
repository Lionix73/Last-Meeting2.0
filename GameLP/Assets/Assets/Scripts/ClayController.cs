using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayController : MonoBehaviour
{
    public float speed = 3.0f;

    Rigidbody2D rigidbody2d;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    float horizontal;
    float vertical;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        animator.SetFloat("Speed", move.magnitude);
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.y = position.y + speed * vertical * Time.deltaTime;
        position.x = position.x + speed * horizontal * Time.deltaTime;

        rigidbody2d.position = position;
    }
}
