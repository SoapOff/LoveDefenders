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
     public bool UneFois;
     public  GameObject[] ListIA;
     public  int index;
     public GenerateurOk generateurOk;
    // Start is called before the first frame update
    void Start()
    {
        generateurOk=GameObject.FindObjectOfType<GenerateurOk>();
        SpawnOuPas=Random.Range(1,4);
        index = Random.Range (0, ListIA.Length);
                Monstre=ListIA[index];
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnOuPas==1){
            transformSpawn[0].SetActive(false);
             transformSpawn[1].SetActive(false);
              index = Random.Range (0, ListIA.Length);
                Monstre=ListIA[index];
        }
        if(SpawnOuPas==2){
             transformSpawn[2].SetActive(false);
              index = Random.Range (0, ListIA.Length);
        Monstre=ListIA[index];
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
            
            index = Random.Range (0, ListIA.Length);
            Monstre=ListIA[index];
             Instantiate(Monstre, new Vector3(transformSpawn[2].GetComponent<Transform>().position.x,transformSpawn[2].GetComponent<Transform>().position.y,0.01f), Quaternion.identity);
             nombremonstre=1;
             index = Random.Range (0, ListIA.Length);
             Monstre=ListIA[index];
        
        }
        if(SpawnOuPas==2)
        {
            
             Instantiate(Monstre, new Vector3(transformSpawn[0].GetComponent<Transform>().position.x,transformSpawn[0].GetComponent<Transform>().position.y,0.01f), Quaternion.identity);
             index = Random.Range (0, ListIA.Length);
             Monstre=ListIA[index];
              Instantiate(Monstre, new Vector3(transformSpawn[1].GetComponent<Transform>().position.x,transformSpawn[1].GetComponent<Transform>().position.y,0.01f ), Quaternion.identity);
              index = Random.Range (0, ListIA.Length);
              Monstre=ListIA[index];
             nombremonstre=2;
        }
        if(SpawnOuPas==3)
        {
            
             Instantiate(Monstre, new Vector3(transformSpawn[0].GetComponent<Transform>().position.x,transformSpawn[0].GetComponent<Transform>().position.y,0.01f ), Quaternion.identity);
             index = Random.Range (0, ListIA.Length);
             Monstre=ListIA[index];
              Instantiate(Monstre, new Vector3(transformSpawn[1].GetComponent<Transform>().position.x,transformSpawn[1].GetComponent<Transform>().position.y,0.01f ), Quaternion.identity);
              index = Random.Range (0, ListIA.Length);
              Monstre=ListIA[index];
              Instantiate(Monstre, new Vector3(transformSpawn[2].GetComponent<Transform>().position.x,transformSpawn[2].GetComponent<Transform>().position.y,0.01f), Quaternion.identity);
              index = Random.Range (0, ListIA.Length);
              Monstre=ListIA[index];
             nombremonstre=3;
        }
    }
}
