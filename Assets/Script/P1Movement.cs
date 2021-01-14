using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputMovement();
    }

    void InputMovement()
    {
        float moveX = Input.GetAxisRaw("Vertical");
        float moveY = Input.GetAxisRaw("Horizontal");

        moveDirection = new Vector2(moveY, moveX).normalized;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
