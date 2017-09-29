using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    public GameObject bird;
    public GameObject pipe;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pipe")
        {
            return;
        }
        Instantiate(pipe, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(bird, other.transform.position, other.transform.rotation);
            
        }

        Destroy(other);
       
    }
}
