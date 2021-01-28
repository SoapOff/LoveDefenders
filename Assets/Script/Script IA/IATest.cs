using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATest : MonoBehaviour
{

    public Transform Player;
    public float moveSpeed = 12f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public float Radius = 20f;
    public float Range = 25f;
    private bool OutRange = true;


    //public float RadiusOfRaycast;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

     Debug.DrawRay(transform.position,transform.TransformDirection(Vector2.right) * 25f, Color.green);
     
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), Range);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, Radius, transform.TransformDirection(Vector2.right),Range);

        if (hit)
        {
           

            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;

            OutRange = false;
            moveSpeed = 12f;
        }
        else
        {   
            OutRange = true;
        }

        if (OutRange == true)
        {
            Patrolling();
        }
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void Patrolling()
    {
        moveSpeed = 0f;
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
       // Gizmos.color = Color.green;
       // Gizmos.DrawSphere(transform.position, Radius);
    }
}
