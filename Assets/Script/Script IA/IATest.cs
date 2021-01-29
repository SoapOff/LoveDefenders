using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATest : MonoBehaviour
{

    public GameObject Player;
    public GameObject Player2;
    public float moveSpeed = 12f;
    public float ValeurChangeSpeed;

    private Rigidbody2D rb;
    private Vector2 movement;

    public float Radius = 20f;
    public float Range = 25f;
    private bool OutRange = true;
    public float Randomtarget;

    public QuitterRetry quitterRetry;
    private bool OkUne;
     public AudioSource ToucherRobot;
     public GameObject Liens;


    //public float RadiusOfRaycast;

    // Start is called before the first frame update
    void Start()
    {
         quitterRetry=GameObject.FindObjectOfType<QuitterRetry>();
        moveSpeed=Random.Range(0.6f,0.9f);
        ValeurChangeSpeed=Random.Range(0.6f,0.9f);
        Randomtarget=Random.Range(0,2);
        rb = this.GetComponent<Rigidbody2D>();
        Player=GameObject.FindWithTag("Player");
         Player2=GameObject.FindWithTag("Player2");
          Liens=GameObject.FindWithTag("Liens");
          ToucherRobot=GameObject.FindWithTag("ToucherRobot").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

     Debug.DrawRay(transform.position,transform.TransformDirection(Vector2.right) * 25f, Color.green);
     
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), Range);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, Radius, transform.TransformDirection(Vector2.right),Range);

        if (hit&&Randomtarget==0)
        {
           

            Vector3 direction = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;

            OutRange = false;
            moveSpeed = ValeurChangeSpeed;
        }
        else
        {   
            OutRange = true;
        }

        if (OutRange == true)
        {
            Patrolling();
        }

        if (hit&&Randomtarget==1)
        {
           

            Vector3 direction = Player2.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;

            OutRange = false;
            moveSpeed = ValeurChangeSpeed;
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
        moveSpeed = 1f;
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
       // Gizmos.color = Color.green;
       // Gizmos.DrawSphere(transform.position, Radius);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"&&!OkUne|| other.tag=="Player2"&&!OkUne){

            OkUne=true;
            Liens.SetActive(false);
            Player.GetComponent<BoxCollider2D>().enabled=false;
            Player2.GetComponent<BoxCollider2D>().enabled=false;
            ToucherRobot.Play();
            Debug.Log("PERDDDDDDDDDDDDDDDDDDDDDU");
            quitterRetry.Perdu();
            // mettre can move false;
        }
    }
}
