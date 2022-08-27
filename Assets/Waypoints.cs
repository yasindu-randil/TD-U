using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        // Get the number of Way points
        points = new Transform[transform.childCount];

        // Populate the transform array with the waypoints
        for(int i=0; i< points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
