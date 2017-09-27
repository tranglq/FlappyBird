using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe1 : MonoBehaviour {

    public GameObject pipeSample;
    public float yMinPositionPipe, yMaxPositionPipe;
    public int sizeOfPipe;
    public float speed;

    private GameObject[] pipes;
    private int presentPipe = 0;

    private Vector2 pipePosition = new Vector2(-12,0);
    private float yPosition, xPosition = 10f;
    private float timeToNextPipe;

    void Start()
    {
        timeToNextPipe = 0f;                  // Time of 2 pipe appearent is 0
        pipes = new GameObject[sizeOfPipe];     // Declare 'sizeOfPipe' object pipes

        // i inscreases from 0 to sizeOfPipe.
        for(int i = 0; i < sizeOfPipe; i++)
        {
            //1 new object, which like a 'pipe object', is created in pipePosition 
            pipes[i] = (GameObject)Instantiate(pipeSample, pipePosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        //Time of next pipe's appearent equal time of previous pipe's appearent plus delta time
        timeToNextPipe += Time.deltaTime;

        //if timeToNextPipe < speed, there are too many pipes on screen, so timeToNextPipe need to restart 0; 
        if (timeToNextPipe >= speed)
        {
            timeToNextPipe = 0;


            yPosition = Random.Range(yMinPositionPipe, yMaxPositionPipe);
            pipes[presentPipe].transform.position = new Vector2(xPosition, yPosition);

            presentPipe++;
            if(presentPipe >= sizeOfPipe)
            {
                presentPipe = 0;
            }
            

        }

    }
  

}
