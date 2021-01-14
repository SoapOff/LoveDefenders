using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour
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
        float moveX = Input.GetAxisRaw("P2_Vertical");
        float moveY = Input.GetAxisRaw("P2_Horizontal");

        moveDirection = new Vector2(moveY, moveX).normalized;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
