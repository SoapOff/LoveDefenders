using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleDebut : MonoBehaviour
{
    public List<GameObject> portes = new List<GameObject>();

     public bool MoveToSallePos;

      public GameObject cam;
      public Transform transformSalle;
    // Start is called before the first frame update
    void Start()
    {
        cam=GameObject.FindWithTag("MainCamera");
        	StartCoroutine(coroutineA());
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveToSallePos==true){
			cam.transform.position = Vector3.MoveTowards(cam.transform.position, transformSalle.position, 0.05f);
		}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag=="Player"){
			MoveToSallePos=true;
		}
    }
    private void OnTriggerExit2D(Collider2D other)
    {
		if(other.tag=="Player"){
			MoveToSallePos=false;
		}
    }

    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(3f);
		foreach(GameObject Portes in GameObject.FindGameObjectsWithTag("Portes"))
		 {
 
             portes.Add(Portes);
         }
       
    }
}
