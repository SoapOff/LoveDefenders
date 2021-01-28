using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    float rotation;
    public float rotationSpeed = 15f;
    public bool Activated = true;
    // Update is called once per frame
    void Update()
    {
        if (Activated == true)
        {
            rotation += Time.deltaTime * rotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
