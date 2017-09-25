using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe1 : MonoBehaviour {

    public GameObject exploision;
    public GameObject playerExploision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "Pipe")
        {
            return;
        }

        Instantiate(exploision, transform.position, transform.rotation);
        if(gameObject.tag == "Player")
        {
            Instantiate(playerExploision, transform.position, transform.rotation);
//            GameController.GameOver();
        }

        
    }
}
