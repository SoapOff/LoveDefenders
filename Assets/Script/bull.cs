using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bull : MonoBehaviour
{

    public Transform Player;
    public float moveSpeed = 50f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public float Radius = 20f;
    public float Range = 0f;
    private bool OutRange = true;

    private bool Charge = false;
    private float charging = 0f;
    //public float RadiusOfRaycast;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * Radius, Color.green);

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), Range);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, Radius, transform.TransformDirection(Vector2.right), Range);
        hit.transform.GetComponent<SpriteRenderer>().color = Color.green;

        if (hit)
        {
            charging += Time.deltaTime;
        }
        else
        {
            OutRange = true;
        }

       /* if (OutRange == true)
        {
            Patrolling();
        }*/

        if (charging > 2)
        {
            charging = 0;
            Charge = true;
        }
        if (Charge == true)
        {


            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;

            OutRange = false;
            moveSpeed = 50f;
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
}

