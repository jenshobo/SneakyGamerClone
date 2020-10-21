using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool idle;

    [Header("rest objects")]
    public GameObject mainLight;

    [Header("camera position objects")]
    public GameObject mainCameraPosition;
    public GameObject hitCameraPosition;
    public GameObject parkCameraPosition;
    public GameObject lightCameraPosition;

    [Header("minigame parent objects")]
    public GameObject main;
    public GameObject shoot;
    public GameObject jump;
    public GameObject hit;
    public GameObject park;
    public GameObject _light;

    [Header("sliders (could be a single one but no)")]
    public Slider shootSlider;
    public Slider jumpSlider;
    public Slider hitSlider;
    public Slider parkSlider;
    public Slider lightSlider;

    [Header("manager scripts")]
    public MiniGameManager miniGameManager;
    public EnemyManager enemyManager;

    [Header("rest variables")]
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

        main.SetActive(false);

        int random = Random.Range(1, 6);

        switch (random)
        {
            case 1:
                shoot.SetActive(true);
                miniGameManager.SetUpMiniGame(shootSlider, false);
                gameObject.transform.position = mainCameraPosition.transform.position; gameObject.transform.rotation = main.transform.rotation;
                break;
            case 2:
                jump.SetActive(true);
                miniGameManager.SetUpMiniGame(jumpSlider, true);
                gameObject.transform.position = mainCameraPosition.transform.position; gameObject.transform.rotation = main.transform.rotation;
                break;
            case 3:
                hit.SetActive(true);
                miniGameManager.SetUpMiniGame(hitSlider, false);
                gameObject.transform.position = hitCameraPosition.transform.position; gameObject.transform.rotation = hitCameraPosition.transform.rotation;
                break;
            case 4:
                park.SetActive(true);
                miniGameManager.SetUpMiniGame(parkSlider, false);
                gameObject.transform.position = parkCameraPosition.transform.position; gameObject.transform.rotation = parkCameraPosition.transform.rotation;
                break;
            case 5:
                _light.SetActive(true);
                miniGameManager.SetUpMiniGame(lightSlider, true);
                gameObject.transform.position = lightCameraPosition.transform.position; gameObject.transform.rotation = lightCameraPosition.transform.rotation;
                break;
        }
    }

    public void AddScore(int i)
    {
        playingMiniGame = false;

        score += i;
        if (i != 0 && enery <= .8f)
            enery += .2f;
        if (i == 0)
            lives--;

        shoot.SetActive(false);
        jump.SetActive(false);
        hit.SetActive(false);
        park.SetActive(false);
        _light.SetActive(false);
        mainLight.SetActive(true);
        main.SetActive(true);
        gameObject.transform.position = mainCameraPosition.transform.position; gameObject.transform.rotation = main.transform.rotation;
    }
}
