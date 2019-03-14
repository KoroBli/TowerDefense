using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool endGame = false;
	
	// Update is called once per frame
	void Update ()
    {
        if (endGame) return;

		if(PlayerStats.lives <= 0)
        {
            GameOver();
        }
	}

    void GameOver()
    {
        endGame = true;
    }
}
