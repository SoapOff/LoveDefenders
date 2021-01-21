using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

	private RoomTemplates templates;
	public static float NombreSalle;
	public bool SalleClean;
	public static bool jeSuisEnCombat;
	 public List<GameObject> portes = new List<GameObject>();
	 public bool EnemiesTousMorts;
	 public GameObject cam;
	 public Transform transformSalle;
	 public Spawner spawner;
	 public static float NombreMonstreMort;

	 public bool MoveToSallePos;

	void Start()
	{
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		templates.rooms.Add(this.gameObject);
		NombreSalle+=1;

		cam=GameObject.FindWithTag("MainCamera");

		StartCoroutine(coroutineA());
	}
	private void Update() 
	{
		Debug.Log(NombreSalle);

		if(SalleClean&&!jeSuisEnCombat)
		{
			 for (var i = 0; i < portes.Count; i++)
             {
                   portes[i].GetComponent<Animator>().SetBool("Ouvre", true);
				   portes[i].GetComponent<Animator>().SetBool("Ferme", false);
				   Debug.Log("Portes ouvertes");
				   portes[i].GetComponentInChildren<BoxCollider2D>().enabled=false;

             }
        }

		if(EnemiesTousMorts==true){
			SalleFini();
			EnemiesTousMorts=false;
		}

		if(MoveToSallePos==true){
			cam.transform.position = Vector3.MoveTowards(cam.transform.position, transformSalle.position, 0.075f);
		}
	}

	
	public void SalleFini()
	{
		 SalleClean=true;
		 jeSuisEnCombat=false;
    }

	private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"&&SalleClean==false){
			StartCoroutine(coroutineB());
		}
		if(other.tag=="Player"&&SalleClean==true){
			Debug.Log("Déjà venu ici , pas de combat");
		}
		if(other.tag=="Player"){
			Debug.Log("Entre dans pièce");
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

	IEnumerator coroutineB()
    {
		 yield return new WaitForSeconds(0.5f);
        for (var i = 0; i < portes.Count; i++)
             {
				 jeSuisEnCombat=true;
                   portes[i].GetComponent<Animator>().SetBool("Ferme", true);
				   portes[i].GetComponent<Animator>().SetBool("Ouvre", false);
				   Debug.Log("Portes fermées");
				   portes[i].GetComponentInChildren<BoxCollider2D>().enabled=true;

             }
			  yield return new WaitForSeconds(1f);
			  spawner.Spawn();

    }
}

