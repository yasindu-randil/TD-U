using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Movement(Speed);
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var deltaTime = Time.deltaTime;

        transform.position += movement.Calculate(h, v, deltaTime);
    }
}
