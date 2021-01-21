using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomComplete : MonoBehaviour
{
    public bool roomFini;
    public List<Animator> listeAnim = new List<Animator>();
    // Start is called before the first frame update

    public bool Jeviensduhaut;
    public bool Jeviensdubas;
    public bool Jeviensdedroite;
    public bool Jeviensdegauche;
    public static float jeViensDeOu;
    public bool jesuisdanslasalle;
    public GameObject AnimatorQueJeVeux;
    // pour detecter de quelle salle on parle.



    // Si 1 , je viens du haut
    // Si 2 je viens du bas
    // Si 3 je viens de la gauche
    // Si 4 je viens de la droite
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(roomFini==true){

                         for (var i = 0; i < listeAnim.Count; i++)
             {
                   listeAnim[i].SetBool("Ouvert", true);
             }
        }
        else
        {
            for (var i = 0; i < listeAnim.Count; i++)
             {
                   listeAnim[i].SetBool("Ouvert", false);
             }
        }



            // En gros quand on pourra mettre les colliders pour OnTriggerEnter , On mettra la valeur de JeviensDeOu pour que la porte dans
            // laquelle on arrive , soit ouverte.


            if(jesuisdanslasalle&&Jeviensduhaut){
            Debug.Log("OuvrePorteBas");
            OuvrePorteBas();
        }
        if(jesuisdanslasalle&&Jeviensdubas){
            Debug.Log("OuvrePorteHaut");
            OuvrePorteHaut();
        }
         if(jesuisdanslasalle&&Jeviensdegauche){
             Debug.Log("OuvrePorteDroite");
            OuvrePorteDroite();
        }
         if(jesuisdanslasalle&&Jeviensdedroite){
             Debug.Log("OuvrePorteGauche");
            OuvrePorteGauche();
        }
    }
    public void OuvrePorteHaut()
    {
 // Ouvre porte Haut
           AnimatorQueJeVeux= this.gameObject.transform.GetChild (0).gameObject;
           AnimatorQueJeVeux.GetComponent<Animator>().SetBool("Ouvert", true);
    }
    public void OuvrePorteBas()
    {
         // Ouvre porte Bas
              AnimatorQueJeVeux= this.gameObject.transform.GetChild (1).gameObject;
              AnimatorQueJeVeux.GetComponent<Animator>().SetBool("Ouvert", true);
    }
    public void OuvrePorteGauche()
    {
        // Ouvre porte Gauche
              AnimatorQueJeVeux= this.gameObject.transform.GetChild (2).gameObject;
              AnimatorQueJeVeux.GetComponent<Animator>().SetBool("Ouvert", true);
    }
    public void OuvrePorteDroite()
    {
        // Ouvre porte Droite
             AnimatorQueJeVeux= this.gameObject.transform.GetChild (3).gameObject;
              AnimatorQueJeVeux.GetComponent<Animator>().SetBool("Ouvert", true);
    }
}
