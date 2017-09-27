using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float scrollSpeed;
    public bool gameOver = false;


    public void IsDead()
    {
        gameOver = true;
    }
}
