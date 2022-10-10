using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayController : MonoBehaviour
{
    public float speed = 3.0f;

    public float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCoolDown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        activeMoveSpeed = speed;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter <= 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCoolCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if (dashCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.y = position.y + speed * vertical * Time.deltaTime;
        position.x = position.x + speed * horizontal * Time.deltaTime;

        rigidbody2d.position = position;
    }
}
