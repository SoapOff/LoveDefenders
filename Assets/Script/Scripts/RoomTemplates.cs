using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
	private bool spawnedGenerateur;
	public GameObject generateur;
	public GameObject Outils;
	public float SpawnTempsGenerateur1=3;
	public float SpawnTempsGenerateur2=1;
	public float NombreRooms=10;

	void Update(){

		if(waitTime <= 0 && spawnedGenerateur == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-SpawnTempsGenerateur1){
					Instantiate(generateur, rooms[i].transform.position, Quaternion.identity);
					//spawnedGenerateur = true;
				}
				if(i == rooms.Count-SpawnTempsGenerateur2){
					Instantiate(Outils, rooms[i].transform.position, Quaternion.identity);
					spawnedGenerateur = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
