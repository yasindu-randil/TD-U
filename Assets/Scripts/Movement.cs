using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Movement(float spd)
    {
        speed = spd;
    }


    public Vector3 Calculate(float h, float v, float deltaTime)
    {
        var x = h * speed * deltaTime;
        var z = v * speed * deltaTime;

        return new Vector3(x, 0, z);
    }
}
