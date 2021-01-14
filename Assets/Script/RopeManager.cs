using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    private LineRenderer _lineRenderer; 
    private DistanceJoint2D _distanceJoint;

    [SerializeField] private GameObject player2;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _distanceJoint = GetComponent<DistanceJoint2D>();
    }

    void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, player2.transform.position);
    }
}
