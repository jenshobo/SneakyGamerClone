using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool idle;

    public EnemyManager enemyManager;

    public Text scoreText;
    public Text statusText;
    public Text livesText;
    public Slider enerySlider;

    public float enery;
    public float eneryDelay = 0.2f;

    static int lives = 3;
    static int score;

    float time;
    int playerStatus = 0; // 0 = idle, 1 = hide, 2 = playing mini game
    bool toggle = true;
    bool hiding;

    void Update()
    {
        if (idle)
            return;

        // UI managment
        enerySlider.value = enery;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if (time <= Time.time && hiding)
        {
            time = Time.time + eneryDelay;
            enery -= .01f;
        }

        // event manager
        //if (enery <= 0 || enemyManager.isWatching && !hiding || lives <= 0)
        //{
        //    Debug.Log("game over");
        //    // end the game with score and what not
        //}

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
        switch (playerStatus) // statusText not needed later, just for debugging
        {
            case 0:
                statusText.text = "Player Status: ilde"; Ilde(); break;
            case 1:
                statusText.text = "Player Status: hidden"; Hide(); break;
            case 2:
                statusText.text = "Player Status: playing mini game"; StartMiniGame(); break; 
        }
    }

    void StartMiniGame()
    {
        hiding = false;
        playerStatus = 0;
        toggle = true;

        SceneManager.LoadScene(Random.Range(1, 4));
    }

    void Hide()
    {
        hiding = true;
    }

    void Ilde()
    {
        hiding = false;
    }

    public void AddScore(int i) // call this at the end of a minigame
    {
        score += i;
        if (i != 0)
            enery += .2f;
        else
            lives--;

        SceneManager.LoadScene(0);
    }
}
