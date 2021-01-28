using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKey : MonoBehaviour
{
    [SerializeField] private AnimationCurve myCurve;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
