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
    public Text livesText;
    public Slider enerySlider;

    public float eneryDelay = 0.2f;

    static float enery = 1;
    static int lives = 3;
    static int score;

    float time;
    public bool paused;

    void Update()
    {
        if (Input.GetKey("left shift"))
            paused = true;
        else
            paused = false;

        if (enery <= 0 || enemyManager.watching && !paused || lives <= 0)
        {
            Debug.Log("game over");
            // end the game
        }

        if (time <= Time.time && paused)
        {
            time = Time.time + eneryDelay;
            enery -= .01f;
        }

        if (idle)
            return;


        // UI managment
        enerySlider.value = enery;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if (Input.GetKeyDown("space"))
            StartMiniGame();
    }

    void StartMiniGame()
    {
        paused = false;

        SceneManager.LoadScene(Random.Range(1, 6));
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
