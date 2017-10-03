using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;




public class PlayerController : MonoBehaviour {
    public float yMin, yMax;
    public float speed;
    public float tilt;
    public GameController gameController;

    private Rigidbody2D rb;
    private Vector2 movement;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update () {

        //Declare input value
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(-0.0f, moveVertical);        //Fixed position x of player and moves on position y
        rb.velocity = movement * speed;                     //Calculation velocity of bird 

        //Setting limited position
        rb.position = new Vector2
        (
            -0.0f,
            Mathf.Clamp(rb.position.y, yMin, yMax)
        );

        if(Input.anyKeyDown)
        {
            Rotate(tilt, movement);
        }
        else
        {
            Rotate(-tilt, movement);
        }
    }

    void Rotate(float tilt, Vector2 movement)
    {
        Vector3 movement3D = movement;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, -tilt * movement3D.y * speed);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Pipe")) || (other.gameObject.CompareTag("Brick")))
        {
            gameController.GameOver();
            Debug.Log("collision!");

        }
    }



}
