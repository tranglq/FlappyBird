using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController gameController;
    public GameObject pipe1, pipe2;
    public GameObject player;
    public Vector2 scrollValuePipe;

    public int pipeCount;
    public float scrollWait;
    public float startWait;
    public float pipeWait;
    public TextMesh textM;
    public TextMesh textScore;

    public bool isDead;

    private int score = 0;

	void Start () {
        StartCoroutine(ScrollPipe());
        textM.text = "";
        isDead = false;
     //   TextScore();
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

                if((player.transform.position.x == pipe1.transform.position.x) && (i > 0))
                {
                    Debug.Log("score1");
                    score = score + 1;
                    Debug.Log("score2");
                    TextScore();
                    Debug.Log("score3");
                }
                yield return new WaitForSeconds(scrollWait);
            }
            yield return new WaitForSeconds(pipeWait);

        }
       
    }

    public void TextScore()
    {
        textScore.text = "Score: " + score;
    }

    public void GameOver()
    {
        
        textM.text = "GameOver!!";
        Debug.Log("GameOver!");
        isDead = true;
        Debug.Log("isDead is true");
        Time.timeScale = 0;
    }
}
