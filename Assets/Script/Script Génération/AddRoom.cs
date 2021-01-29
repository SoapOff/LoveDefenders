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
	 private bool PeutJouerSon;
	private bool JoueSon;
	public bool P2Rentre;
	public AudioSource PorteMonte;
	public GenerateurOk generateurOk;
	private bool New;

	void Start()
	{
		generateurOk=GameObject.FindObjectOfType<GenerateurOk>();
		PeutJouerSon=true;
		PorteMonte= GameObject.FindGameObjectWithTag("PorteMonte").GetComponent<AudioSource>();
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		templates.rooms.Add(this.gameObject);
		NombreSalle+=1;

		cam=GameObject.FindWithTag("MainCamera");

		StartCoroutine(coroutineA());
	}
	private void Update() 
	{

		if(PeutJouerSon&&JoueSon){
			PorteMonte.Play();
			PeutJouerSon=false;
			JoueSon=false;
		}

		Debug.Log(NombreSalle);

		if(SalleClean&&!jeSuisEnCombat)
		{
			 for (var i = 0; i < portes.Count; i++)
             {
				 JoueSon=true;
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
			cam.transform.position = Vector3.MoveTowards(cam.transform.position, transformSalle.position, 0.05f);
		}
	}

	
	public void SalleFini()
	{
		 SalleClean=true;
		 jeSuisEnCombat=false;
    }

	private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"&&SalleClean==false&&P2Rentre){
			EnemiesTousMorts=false;
			StartCoroutine(coroutineB());
		}
		if(other.tag=="Player"&&SalleClean==true&&GenerateurOk.ElecOk==false){
			Debug.Log("Déjà venu ici , pas de combat");
		}
		if(other.tag=="Player"){
			Debug.Log("Entre dans pièce");
			MoveToSallePos=true;
		}
		if(other.tag=="Player2"){
			P2Rentre=true;
		}
		if(other.tag=="Player"&&GenerateurOk.ElecOk==true&&New==false){
			New=true;
			EnemiesTousMorts=false;
			StartCoroutine(coroutineB());
		}
    }

	private void OnTriggerExit2D(Collider2D other)
    {
		if(other.tag=="Player"){
			MoveToSallePos=false;
		}
		if(other.tag=="Player2"){
			P2Rentre=false;
		}
    }

	private void OnTriggerStay2D(Collider2D other) {
		if(other.tag=="Player"&&SalleClean==false&&P2Rentre){
			P2Rentre=false;
			StartCoroutine(coroutineB());
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
				  PorteMonte.Play();
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

