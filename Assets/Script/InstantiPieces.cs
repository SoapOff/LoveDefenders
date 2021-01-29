using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiPieces : MonoBehaviour
{
    public List<Transform> maListe =new List<Transform>();
    public List< GameObject> mecanique=new List<GameObject>();
    public int index;
    public int deuxdex;
    public float RandomPieces;
    private bool UneFois;

    // Start is called before the first frame update
    void Start()
    {
        //RandomPieces=Random.Range(3,7);
        RandomPieces=Random.Range(10,20);
    }

    // Update is called once per frame
    void Update()
    {
        index=Random.Range(0,mecanique.Count);
         deuxdex=Random.Range(0,maListe.Count);
    }
    public void SpawnPieces(){
        if(UneFois==false)
        {
            UneFois=true;
             for(int i = 0; i < RandomPieces; i++)
        {
            Instantiate(mecanique[index], new Vector3(maListe[deuxdex].position.x,maListe[deuxdex].position.y,maListe[deuxdex].position.z), Quaternion.identity);
            index=Random.Range(0,mecanique.Count);
         deuxdex=Random.Range(0,maListe.Count);
        }
        
    }
    }
}
