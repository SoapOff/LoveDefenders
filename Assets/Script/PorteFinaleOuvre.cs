using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteFinaleOuvre : MonoBehaviour
{
    public static bool OutilRecup;
    public static bool GenerateurOk;
    private bool UneFois;
    public GameObject CameraMain;
    public GameObject CameraPorte;
    public GameObject PorteFinal;
    public Transform target;
    public bool Test;
    private bool OneTime;
    private bool Allez;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OutilRecup&&GenerateurOk&&!UneFois)
        {
            CameraSurPorteOuvre();
        }

        if(Test==true&&OneTime==false)
        {
            OneTime=true;
            OutilRecup=true;
            GenerateurOk=true;
        }
    }

    public void CameraSurPorteOuvre()
    {
        if(Allez==false)
        {
        Allez=true;
        StartCoroutine(coroutineA());
        }
    }

    IEnumerator coroutineA()
    {
        yield return new WaitForSeconds(0.5f);
        CameraPorte.SetActive(true);
        CameraMain.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        PorteFinal.SetActive(false);
        yield return new WaitForSeconds(1f);
        CameraPorte.SetActive(false);
        CameraMain.SetActive(true);
       
    }
}
