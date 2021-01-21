using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DansPorte : MonoBehaviour
{
    public Transform Target;
    public Transform Vala;
    // Start is called before the first frame update
    void Start()
    {
         Target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            Target.position=new Vector3(Vala.position.x,Vala.position.y,Vala.position.z);


        }
    }
}
