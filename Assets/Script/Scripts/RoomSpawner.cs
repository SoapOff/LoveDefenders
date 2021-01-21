using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private RoomTemplates templates;
	public int rand;
	public bool spawned = false;

	public float waitTime = 4f;
	public static float NombredeRooms;
	public float NombredeRoomsVoulu=10;
	public AddRoom addRoom;
	public static bool ArreteSpawn;

	void Start(){
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);

		if(AddRoom.NombreSalle>=NombredeRoomsVoulu){
			ArreteSpawn=true;
			Debug.Log("Nombre de salle atteint , je met les salles qui bloques");
			rand=0;
	}
	}
	private void Awake() {
		NombredeRoomsVoulu=10f;
		if(AddRoom.NombreSalle>=NombredeRoomsVoulu){
			ArreteSpawn=true;
			Debug.Log("Nombre de salle atteint , je met les salles qui bloques");
	}
	}


	void Spawn(){
		if(spawned == false&&!ArreteSpawn){
			if(openingDirection == 1){
				// Need to spawn a room with a BOTTOM door.
				rand = Random.Range(1, templates.bottomRooms.Length);
				Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
				Debug.Log("Salle avec porte en bas normal");
			//	NombredeRooms+=1;
			} else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.
				rand = Random.Range(1, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
				Debug.Log("Salle avec porte en haut normal");
				//NombredeRooms+=1;
			} else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.
				rand = Random.Range(1, templates.leftRooms.Length);
				Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
				Debug.Log("Salle avec porte a gauche normal");
			//	NombredeRooms+=1;
			} else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.
				rand = Random.Range(0,4);
				Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
				Debug.Log("Salle avec porte a droite normal");
			//NombredeRooms+=1;
			}	
			spawned = true;
			
			}

			if(spawned == false&&ArreteSpawn){
			if(openingDirection == 1){
				// Need to spawn a room with a BOTTOM door.
				rand = 0;
				Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
				Debug.Log("Salle avec porte en bas bloqué");
			//	NombredeRooms+=1;
			} else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.
				rand = 0;
				Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
				Debug.Log("Salle avec porte en haut normal");
				//NombredeRooms+=1;
			} else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.
				rand = 0;
				Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
				Debug.Log("Salle avec porte à gauche normal");
			//	NombredeRooms+=1;
			} else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.
				rand = 4;
				Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
				Debug.Log("Salle avec porte à droite bloqué");
			//NombredeRooms+=1;
			}	
			spawned = true;
			
			}
		}
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint")){
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			} 
			spawned = true;
		}
	}
	private void Update() {
		//Debug.Log(openingDirection);

		if(AddRoom.NombreSalle>=NombredeRoomsVoulu){
			ArreteSpawn=true;
			Debug.Log("Nombre de salle atteint , je met les salles qui bloques");
	}
}
}
