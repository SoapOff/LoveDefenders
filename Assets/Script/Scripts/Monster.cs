using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public bool TesMort;
    private bool Unefois;
    public Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TesMort==true&&Unefois==false){
            Unefois=true;
            Spawner.NombreMonstreMort+=1;
            Debug.Log(Spawner.NombreMonstreMort);
            this.GetComponent<SpriteRenderer>().enabled=false;
        }
    }
}
