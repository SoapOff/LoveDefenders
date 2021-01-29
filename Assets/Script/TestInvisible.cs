using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInvisible : MonoBehaviour
{
    public SpriteRenderer Player1;
    public SpriteRenderer Player2;
    // Start is called before the first frame update
    void Start()
    {
        Player1=GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        Player2=GameObject.FindWithTag("Player2").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
        {
            Player1.enabled=false;
        }
         if(other.tag=="Player2")
        {
            Player2.enabled=false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player")
        {
            Player1.enabled=true;
        }
         if(other.tag=="Player2")
        {
            Player2.enabled=true;
        }
    }

     private void OnTriggerStay2D(Collider2D other) {
        if(other.tag=="Player")
        {
            Player1.enabled=false;
        }
         if(other.tag=="Player2")
        {
            Player2.enabled=false;
        }
    }
}
