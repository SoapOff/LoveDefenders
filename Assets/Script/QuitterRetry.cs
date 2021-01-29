using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitterRetry : MonoBehaviour
{
    public AudioSource BoutonClic;
    public GameObject Coeur;

    public GameObject FondBouton;
    public AudioSource Defaite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quitter(){
        StartCoroutine(coroutineA());
    }
    public void Retry(){
        StartCoroutine(coroutineB());
        Application.Quit();
    }
    public void Perdu()
    {
         StartCoroutine(coroutineC());
    }

    IEnumerator coroutineA()
    {
        BoutonClic.Play();
        yield return new WaitForSeconds(1.0f);
         Application.Quit();
       
    }

    IEnumerator coroutineB()
    {
         BoutonClic.Play();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
    IEnumerator coroutineC()
    {
        Defaite.Play();
        Coeur.SetActive(true);
         Coeur.GetComponent<Animator>().SetBool("Go", true);
        yield return new WaitForSeconds(2.0f);
        FondBouton.SetActive(true);
        
       
    }
}
