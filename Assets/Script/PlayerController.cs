using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;




public class PlayerController : MonoBehaviour {
    public float yMin, yMax;
    public float speed;
    public float tilt;
    public GameController gameController;

    private float yRotation;
    private Rigidbody2D rb;
    
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

        if(Input.anyKeyDown)
        {
            yRotation += Input.GetAxis("Horizontal");
            rb.transform.eulerAngles = new Vector3(0, yRotation, 0);
            rb.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            rb.transform.Rotate(Vector2.down * Time.deltaTime);
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            gameController.GameOver();
            Debug.Log("collision!");

        }
    }



}
