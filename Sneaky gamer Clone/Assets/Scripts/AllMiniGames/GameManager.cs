using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool idle;

    public GameObject main;
    public GameObject shoot;
    public GameObject jump;

    public Slider shootSlider;
    public Slider jumpSlider;

    public MiniGameManager miniGameManager;
    public EnemyManager enemyManager;

    public Text gameOverText;
    public Text scoreText;
    public Text livesText;
    public Slider enerySlider;

    public float eneryDelay = 0.2f;

    static float enery = 1;
    static int lives = 3;
    static int score;

    float time;
    bool gameOver = false;
    bool playingMiniGame = false;

    public bool paused;

    void Update()
    {
        if (gameOver)
            return;

        if (Input.GetKey("left shift"))
            paused = true;
        else
            paused = false;

        if (enery <= 0 || enemyManager.watching && !paused || lives <= 0)
        {
            Debug.Log("game over");
            gameOverText.text = "Game Over";
            gameOver = true;
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

        if (Input.GetKeyDown("space") && !playingMiniGame)
            StartMiniGame();
    }

    void StartMiniGame()
    {
        paused = false;
        playingMiniGame = true;

        // testingputting everything into 1 scene
        main.SetActive(false);

        int random = Random.Range(1, 3);

        switch (random)
        {
            case 1: shoot.SetActive(true); miniGameManager.SetUpMiniGame(shootSlider, false); break;

            case 2: jump.SetActive(true); miniGameManager.SetUpMiniGame(jumpSlider, true); break;
        }

        //SceneManager.LoadScene(Random.Range(1, 7));
    }

    public void AddScore(int i)
    {
        playingMiniGame = false;

        score += i;
        if (i != 0 && enery <= .8f)
            enery += .2f;
        if (i == 0)
            lives--;

        // testingputting everything into 1 scene
        shoot.SetActive(false);
        jump.SetActive(false);
        main.SetActive(true);

        //SceneManager.LoadScene(0);
    }
}
