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


    private float charging = 0f;

    public Vector2 worldLimits;

    //public float RadiusOfRaycast;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        
        position.x = Mathf.Clamp(transform.position.x, -worldLimits.x, worldLimits.x);
        position.y = Mathf.Clamp(transform.position.y, -worldLimits.y, worldLimits.y);
        transform.position = position;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * Radius, Color.green);

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), Range);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, Radius, transform.TransformDirection(Vector2.right), Range);


        if (hit)
        {
            charging += Time.deltaTime;
            hit.transform.GetComponent<SpriteRenderer>().color = Color.red;

            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
        else
        {
            OutRange = true;
            charging = 0;
        }

        if (OutRange == true)
        {
            Patrolling();
        }

        if (charging > 2)
        {
            charging = 0;
            ChargeBull();
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

    public void ChargeBull()
    {
        Vector3 direction = Player.position - transform.position;
       // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
       // rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        OutRange = false;
        moveSpeed = 50f;
        Radius = 20f;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, Radius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(worldLimits.x * 2, worldLimits.y * 2, 1.0f));
    }

}

