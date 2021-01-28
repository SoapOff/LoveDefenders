using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [Space]
    [Header("Déplacement")]
    [Range(0, 350)]
    public float speedX = 25; 

    [Range(0, 350)]
    public float speedY = 1; 

    public bool goBack = true;
    public bool goDown = false; 

    public Vector2 worldLimits;

    float rotation;
    public float rotationSpeed = 15f;

    // Update is called once per frame
    void Update()
    {

        Vector3 position = transform.position;

        rotation += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotation);

        if (goBack == true) 
        {
            position.x += speedX * Time.deltaTime;
        }
        else
        {
            position.x -= speedX * Time.deltaTime;
        }
        if (goDown == true)
        {
            position.y += speedY * Time.deltaTime;
        }
        else
        {
            position.y -= speedY * Time.deltaTime;
        }

        //position.x = Mathf.Clamp(position.x, -worldLimits.x, worldLimits.x);
        //position.y = Mathf.Clamp(position.y, -worldLimits.y, worldLimits.y);

        if (position.x > worldLimits.x)
        {
            goBack = false;
        }
        if (position.x < -worldLimits.x)
        {
            goBack = true;
        }

        if (position.y > worldLimits.y)
        {
            goDown = false;
        }
        if (position.y < -worldLimits.y)
        {
            goDown = true;
        }
        transform.position = position; 

    }

    private void OnDrawGizmos() 
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(worldLimits.x * 2, worldLimits.y * 2, 1.0f));

    }
}
