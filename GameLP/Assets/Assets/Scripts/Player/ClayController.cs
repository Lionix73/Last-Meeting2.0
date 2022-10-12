using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidbody2d;

    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

    public float activeMoveSpeed;
    public float dashSpeed = 5;
    public float dashLength = 0.5f, dashCoolDown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    public Animator anim;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        ProcessInputs();
        Animate();

        if (Input.GetKeyDown(KeyCode.F))
        {
        //     if (dashCoolCounter <= 0 && dashCounter <= 0)
        //     {
        //         activeMoveSpeed = dashSpeed;
        //         dashCounter = dashLength;
        //     }

            if(moveDirection.x < 1) {
                moveDirection.y *= dashSpeed;
            }
            else if(moveDirection.y < 1)
            {
                moveDirection.x *= dashSpeed;
            }
            moveDirection.x *= dashSpeed;
            moveDirection.y *= dashSpeed;

            transform.Translate(moveDirection);
        }

        // if (dashCounter <= 0)
        // {
        //     dashCounter -= Time.deltaTime;

        //     if (dashCoolCounter <= 0)
        //     {
        //         activeMoveSpeed = moveSpeed;
        //         dashCoolCounter = dashCoolDown;
        //     }
        // }

        // if (dashCounter > 0)
        // {
        //     dashCoolCounter -= Time.deltaTime;
        // }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
        }
    }

    void Move() 
    {
        rigidbody2d.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Animate()
    {
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
        anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
        anim.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        anim.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }
}
