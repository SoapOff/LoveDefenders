using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnOuPas;
    public List<GameObject> transformSpawn = new List<GameObject>();
    public GameObject Monstre;
    public float nombremonstre;
    public AddRoom addRoom;
     public static float NombreMonstreMort;
    // Start is called before the first frame update
    void Start()
    {
        SpawnOuPas=Random.Range(1,4);
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnOuPas==1){
            transformSpawn[0].SetActive(false);
             transformSpawn[1].SetActive(false);
        }
        if(SpawnOuPas==2){
             transformSpawn[2].SetActive(false);
        }
        if(nombremonstre==NombreMonstreMort&&nombremonstre>0)
        {
            addRoom.SalleFini();
            NombreMonstreMort=0f;
            Debug.Log( NombreMonstreMort);
        }
    }

    public void Spawn()
    {
        if(SpawnOuPas==1)
        {
             Instantiate(Monstre, new Vector3(transformSpawn[2].GetComponent<Transform>().position.x,transformSpawn[2].GetComponent<Transform>().position.y,transformSpawn[2].GetComponent<Transform>().position.z ), Quaternion.identity);
             nombremonstre=1;
        
        }
        if(SpawnOuPas==2)
        {
             Instantiate(Monstre, new Vector3(transformSpawn[0].GetComponent<Transform>().position.x,transformSpawn[1].GetComponent<Transform>().position.y,transformSpawn[1].GetComponent<Transform>().position.z ), Quaternion.identity);
              Instantiate(Monstre, new Vector3(transformSpawn[1].GetComponent<Transform>().position.x,transformSpawn[2].GetComponent<Transform>().position.y,transformSpawn[2].GetComponent<Transform>().position.z ), Quaternion.identity);
             nombremonstre=2;
        }
        if(SpawnOuPas==3)
        {
             Instantiate(Monstre, new Vector3(transformSpawn[0].GetComponent<Transform>().position.x,transformSpawn[0].GetComponent<Transform>().position.y,transformSpawn[0].GetComponent<Transform>().position.z ), Quaternion.identity);
              Instantiate(Monstre, new Vector3(transformSpawn[1].GetComponent<Transform>().position.x,transformSpawn[1].GetComponent<Transform>().position.y,transformSpawn[1].GetComponent<Transform>().position.z ), Quaternion.identity);
              Instantiate(Monstre, new Vector3(transformSpawn[2].GetComponent<Transform>().position.x,transformSpawn[2].GetComponent<Transform>().position.y,transformSpawn[2].GetComponent<Transform>().position.z ), Quaternion.identity);
             nombremonstre=3;
        }
    }
}
