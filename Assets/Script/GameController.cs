using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject pipe1, pipe2;
    public Vector2 scrollValuePipe;

    public int pipeCount;
    public float scrollWait;
    public float startWait;
    public float pipeWait;

    public bool isDead = false;

	void Start () {
        StartCoroutine(ScrollPipe());
        GetComponent<TextMesh>().text = "";

    }

    IEnumerator ScrollPipe()
    {
        yield return new WaitForSeconds(startWait);

        while(true)
        {
            for(int i = 0; i < pipeCount; i++)
            {
                
                float randYPosition = Random.Range(scrollValuePipe.y, scrollValuePipe.y + 3);   //Fixed position y of pipe 1 = random
                Vector2 pipe1Position = new Vector2(scrollValuePipe.x, randYPosition);          // determine position of pipe1
                Vector2 pipe2Position = new Vector2(scrollValuePipe.x,  10 + randYPosition);    // determine position of pipe2

                Quaternion pipe1_2Rotation = Quaternion.identity;

                Instantiate(pipe1, pipe1Position, pipe1_2Rotation);     //Create a new pipe1 object with position = pipe1Position and rotation = pipe1_2Rotation
                Instantiate(pipe2, pipe2Position, pipe1_2Rotation);     //Create a new pipe2 object with position = pipe2Position and rotation = pipe1_2Rotation

                yield return new WaitForSeconds(scrollWait);
            }
            yield return new WaitForSeconds(pipeWait);

        }
       
    }

    public void GameOver()
    {
        isDead = true;
        GetComponent<TextMesh>().text = "GameOver!!";
    }
}
