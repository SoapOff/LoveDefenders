﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private float moveSpeed = 60f;
    private bool facingRight = true;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        InputMovement();
    }

    void InputMovement()
    {
        Vector3 localScale = transform.localScale;
        float moveX = Input.GetAxisRaw("P2_Vertical");
        float moveY = Input.GetAxisRaw("P2_Horizontal");

        moveDirection = new Vector2(moveY, moveX).normalized;
        rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed));
        anim.SetFloat("MoveX", moveY);
        anim.SetFloat("MoveY", moveX);

        if(Input.GetAxisRaw("P2_Horizontal") == 1 || Input.GetAxisRaw("P2_Horizontal") == -1 || Input.GetAxisRaw("P2_Vertical") == 1 || Input.GetAxisRaw("P2_Vertical") == -1)
        {
            anim.SetFloat("LastMoveX", Input.GetAxisRaw("P2_Horizontal"));
            anim.SetFloat("LastMoveY", Input.GetAxisRaw("P2_Vertical"));
        }

        //rotate sprite
        if (moveY > 0)
        {
            facingRight = true;
        }
        else if (moveY < 0)
        {
            facingRight = false;
        }
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }
}
