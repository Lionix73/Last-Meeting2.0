using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayController : MonoBehaviour
{
    public float speed = 3.0f;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.y = position.y + speed * vertical * Time.deltaTime;
        position.x = position.x + speed * horizontal * Time.deltaTime;

        rigidbody2d.position = position;
    }
}
