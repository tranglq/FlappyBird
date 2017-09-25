using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {
    public float yMin, yMax;
    public float speed;

    private void Start()
    {
        GetComponent<Rigidbody2D>();

    }

    void Update () {
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(-2.0f, moveVertical);

        GetComponent<Rigidbody2D>().velocity = movement * speed; // GetComponent<Rigidbody2D>().drag;

        GetComponent<Rigidbody2D>().position = new Vector2
        (
            -2.0f,
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, yMin, yMax)
        );

     
	}
}
