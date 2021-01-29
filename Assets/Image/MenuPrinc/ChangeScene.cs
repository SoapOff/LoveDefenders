using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour

{
    public string Scene;

    public void OnClic() //permet de changer de scene
    {
        SceneManager.LoadScene(Scene);
    }
    public void Quitter(){
        Application.Quit();
    }
}