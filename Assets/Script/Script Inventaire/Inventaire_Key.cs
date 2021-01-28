using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire_Key : MonoBehaviour
{
    Key boolKey;
    [SerializeField] private Image image_key;
    private void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Key");
        boolKey = g.GetComponent<Key>();
    }
    void Update()
    {
        activeKey();
    }

    void activeKey()
    {
        if(boolKey.isKey == true)
        {
            image_key.enabled = true;
        }
    }
}
