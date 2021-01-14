using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;
    public bool canmove;

    void Start()
    {
        canmove=true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputMovement();
    }

    void InputMovement()
    {
        if(canmove==true){
        float moveX = Input.GetAxisRaw("Vertical");
        float moveY = Input.GetAxisRaw("Horizontal");

        moveDirection = new Vector2(moveY, moveX).normalized;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }
}
