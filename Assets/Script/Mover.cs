using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float thrust;

    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(-transform.right * thrust);
    }
	
}
