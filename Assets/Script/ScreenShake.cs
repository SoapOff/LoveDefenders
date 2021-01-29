using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShake : MonoBehaviour
{
    private Transform transform;
     public float shakeDuration = 0f;
     public float shakeMagnitude = 0.7f;
     private float dampingSpeed = 1.0f;
      Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
  {
   transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
   
   shakeDuration -= Time.deltaTime * dampingSpeed;
  }
  else
  {
   shakeDuration = 0f;
   transform.localPosition = initialPosition;
  }
    }
    void Awake()
{
  if (transform == null)
  {
   transform = GetComponent(typeof(Transform)) as Transform;
  }
}
void OnEnable()
 {
  initialPosition = transform.localPosition;
 }
 public void TriggerShake() {
  shakeDuration = 2.0f;
}
}
