/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (IATest))]
public class FieldOfViewEditor : Editor  
{
     void OnSceneGUI()
    {
        IATest fow = (IATest)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.RadiusOfRaycast); ;
    }
}
*/