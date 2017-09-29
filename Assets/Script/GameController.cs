using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject pipe;
    public Vector2 scrollValue;
    public int pipeCount;
    public float scrollWait;
    public float startWait;
    public float pipeWait;

	void Start () {
        StartCoroutine(ScrollPipe());
	}

    IEnumerator ScrollPipe()
    {
        yield return new WaitForSeconds(startWait);

        while(true)
        {
            for(int i = 0; i < pipeCount; i++)
            {
                Vector2 pipePosition = new Vector2(scrollValue.x, Random.Range(scrollValue.y, scrollValue.y + 1));
                Quaternion pipeRotation = Quaternion.identity;
                Instantiate(pipe, pipePosition, pipeRotation);
                yield return new WaitForSeconds(scrollWait);
            }
            yield return new WaitForSeconds(pipeWait);

        }
       
    }
}
