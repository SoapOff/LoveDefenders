﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private float moveSpeed = 60f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        InputMovement();
    }

    void InputMovement()
    {
        float moveX = Input.GetAxisRaw("P2_Vertical");
        float moveY = Input.GetAxisRaw("P2_Horizontal");

        moveDirection = new Vector2(moveY, moveX).normalized;
        //rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed));
    }
}
