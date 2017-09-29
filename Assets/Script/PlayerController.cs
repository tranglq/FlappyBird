using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class PlayerController : MonoBehaviour {
    public float yMin, yMax;
    public float speed;


    private Rigidbody2D rb;
    

    //   private bool isDead = false;
    //   private GameController gameController;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {

        //Declare input value
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(-0.0f, moveVertical);        //Fixed position x of player and moves on position y
        rb.velocity = movement * speed;    //Calculation velocity of bird 

        //Setting limited position
        rb.position = new Vector2
        (
            -0.0f,
            Mathf.Clamp(rb.position.y, yMin, yMax)
        );            
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("collision!");
            rb.velocity = new Vector2(0, 0);
            GameController.GameOver();

        }
    }



}
