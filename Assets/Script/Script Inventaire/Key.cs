using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public bool isKey = false;
    public Image OutilImage;
    public AudioSource KeySon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"||other.tag == "Player2")
        {
            Debug.Log("clef");
            this.gameObject.SetActive(false);
            KeySon.Play();
            isKey = true;
            OutilImage.enabled=true;
        }
    }
    private void Start() {
        OutilImage=GameObject.FindWithTag("ImageKey").GetComponent<Image>();
        KeySon=GameObject.FindWithTag("KeySon").GetComponent<AudioSource>();
    }
}
