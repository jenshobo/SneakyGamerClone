using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnemyManager enemyManager;

    public Text scoreText;
    public Text statusText;
    public Slider enerySlider;

    public int score;
    public float enery;

    int playerStatus = 0; // 0 = idle, 1 = hide, 2 = playing mini game
    bool toggle = true;

    void Update()
    {
        //buttons
        if (Input.GetKeyDown("left shift"))
        {
            playerStatus = 1;
        }
        else if (Input.GetKeyUp("left shift") || Input.GetKeyDown("space") && !toggle)
        {
            playerStatus = 0;
            toggle = true;
        }
        else if (Input.GetKeyDown("space") && toggle)
        {
            playerStatus = 2;
            toggle = false;
        }

        // calling functions
        switch (playerStatus)
        {
            case 0:
                statusText.text = "Player Status: ilde"; StartMiniGame(); break;
            case 1:
                statusText.text = "Player Status: hidden"; Hide(); break;
            case 2:
                statusText.text = "Player Status: playing mini game"; Ilde(); break;
        }
    }

    void StartMiniGame()
    {

    }

    void Hide()
    {
        // enery needs to go down here
    }

    void Ilde()
    {

    }

    public void AddScore(int i) // call this at the end of a minigame
    {
        score += i;
        enery += .2f;
        scoreText.text = "Score: " + score;
    }
}
