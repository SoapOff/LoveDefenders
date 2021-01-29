using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateurOk : MonoBehaviour
{
    public Key key;
    public GameObject IlFaudrait;
    public AudioSource Repare;
    private GameObject Spark;
    public PorteFinaleOuvre porteFinaleOuvre;
    private bool UneFois;
    public static bool ElecOk;
    // Start is called before the first frame update
    void Start()
    {
        porteFinaleOuvre=GameObject.FindObjectOfType<PorteFinaleOuvre>();
         key=GameObject.FindWithTag("Key").GetComponent<Key>();
         IlFaudrait=GameObject.FindWithTag("Faudrait");
         IlFaudrait.SetActive(false);
         Spark=this.transform.GetChild (0).gameObject;
         Repare=GameObject.FindWithTag("Repare").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"&&key.isKey==false||other.tag=="Player2"&&key.isKey==false)
        {
            IlFaudrait.SetActive(true);
            IlFaudrait.GetComponentInChildren<Image>().enabled=true;
         IlFaudrait.GetComponentInChildren<Text>().enabled=true;
         
        }
        if(other.tag=="Player"&&key.isKey==true&&UneFois==false||other.tag=="Player2"&&key.isKey==true&&UneFois==false)
        {
            UneFois=true;
            Repare.Play();
            Spark.SetActive(false);
            key.OutilImage.enabled=false;
            StartCoroutine(coroutineMontrePorte());
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player"&&key.isKey==false||other.tag=="Player2"&&key.isKey==false)
        {
            IlFaudrait.GetComponentInChildren<Image>().enabled=false;
         IlFaudrait.GetComponentInChildren<Text>().enabled=false;
         IlFaudrait.SetActive(false);
        }
    }
    IEnumerator coroutineMontrePorte()
    {
        
        yield return new WaitForSeconds(1.0f);
        porteFinaleOuvre.CameraSurPorteOuvre();
        ElecOk=true;
        Debug.Log("Elec OKK");
       
    }
}
