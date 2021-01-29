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
     public  GameObject[] ListIA;
     public  int index;
     public GenerateurOk generateurOk;
     public bool UneFois;
     public bool DeuxFois;
     public static bool CourantMit;
     public bool OKSalle;
     public float VoitNombreMonstreMort;
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
        VoitNombreMonstreMort=NombreMonstreMort;
        generateurOk=GameObject.FindObjectOfType<GenerateurOk>();

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
            OKSalle=true;
            addRoom.SalleClean=true;
            addRoom.EnemiesTousMorts=true;
            addRoom.SalleFini();
            NombreMonstreMort=0f;
            Debug.Log( NombreMonstreMort);
        }
    }

    public void Spawn()
    {
        if(CourantMit==false)
    {

            
        if(SpawnOuPas==1&&UneFois==false)
        {
            UneFois=true;
            index = Random.Range (0, ListIA.Length);
            Monstre=ListIA[index];
             Instantiate(Monstre, new Vector3(transformSpawn[2].GetComponent<Transform>().position.x,transformSpawn[2].GetComponent<Transform>().position.y,0.01f), Quaternion.identity);
             nombremonstre=1;
             index = Random.Range (0, ListIA.Length);
             Monstre=ListIA[index];
        
        }
        if(SpawnOuPas==2&&UneFois==false)
        {
            UneFois=true;
             Instantiate(Monstre, new Vector3(transformSpawn[0].GetComponent<Transform>().position.x,transformSpawn[0].GetComponent<Transform>().position.y,0.01f), Quaternion.identity);
             index = Random.Range (0, ListIA.Length);
             Monstre=ListIA[index];
              Instantiate(Monstre, new Vector3(transformSpawn[1].GetComponent<Transform>().position.x,transformSpawn[1].GetComponent<Transform>().position.y,0.01f ), Quaternion.identity);
              index = Random.Range (0, ListIA.Length);
              Monstre=ListIA[index];
             nombremonstre=2;
        }
        if(SpawnOuPas==3&&UneFois==false)
        {
            UneFois=true;
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

      if(CourantMit==true)
    {

            
        if(SpawnOuPas==1&&DeuxFois==false)
        {
           DeuxFois=true;
            index = Random.Range (0, ListIA.Length);
            Monstre=ListIA[index];
             Instantiate(Monstre, new Vector3(transformSpawn[2].GetComponent<Transform>().position.x,transformSpawn[2].GetComponent<Transform>().position.y,0.01f), Quaternion.identity);
             nombremonstre=1;
             index = Random.Range (0, ListIA.Length);
             Monstre=ListIA[index];
        
        }
        if(SpawnOuPas==2&&DeuxFois==false)
        {
            DeuxFois=true;
             Instantiate(Monstre, new Vector3(transformSpawn[0].GetComponent<Transform>().position.x,transformSpawn[0].GetComponent<Transform>().position.y,0.01f), Quaternion.identity);
             index = Random.Range (0, ListIA.Length);
             Monstre=ListIA[index];
              Instantiate(Monstre, new Vector3(transformSpawn[1].GetComponent<Transform>().position.x,transformSpawn[1].GetComponent<Transform>().position.y,0.01f ), Quaternion.identity);
              index = Random.Range (0, ListIA.Length);
              Monstre=ListIA[index];
             nombremonstre=2;
        }
        if(SpawnOuPas==3&&DeuxFois==false)
        {
            DeuxFois=true;
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
}
