using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABull : MonoBehaviour
{

    public Transform Player;
    public float moveSpeed = 12f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public float Radius = 20f;
    public float Range = 25f;
    private bool OutRange = true;

    private float Charging = 0f;
    private bool IsCharging = false;
    //public float RadiusOfRaycast;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 25f, Color.green);

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), Range);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, Radius, transform.TransformDirection(Vector2.right), Range);

        if (hit)
        {
            Charging += Time.deltaTime;
            Debug.Log(Charging);
            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
           // direction.Normalize();

            OutRange = false;
           
        }
        else
        {
            OutRange = true;
            IsCharging = false;
        }

        if (OutRange == true)
        {
            Patrolling();
        }

        if (Charging > 2.2f)
        {
            IsCharging = true;

            moveSpeed = 12f;

        }
      if (IsCharging == true)
        {
            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            
            if (OutRange == true)
            { 
            Charging = 0;
            IsCharging = false;
           // moveSpeed = 0f;
            }
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
