using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour {
    private Rigidbody2D rb2D;
    private GameController gameController;

	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(gameController.scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.gameOver == true)
        {
            rb2D.velocity = new Vector2(0,0);

        }
	}
}
