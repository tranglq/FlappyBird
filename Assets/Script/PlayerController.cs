using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {
    public float yMin, yMax;
    public float speed;

 //   private bool isDead = false;
 //   private GameController gameController;


    void Update () {

        //Declare input value
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(-0.0f, moveVertical);        //Fixed position x of player and moves on position y
        GetComponent<Rigidbody2D>().velocity = movement * speed;    //Calculation velocity of bird 
        GetComponent<Rigidbody2D>().position = new Vector2
        (
            -0.0f,
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, yMin, yMax)
        );            
	}

 /*   private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        isDead = true;
        gameController.IsDead();

    } */
}
