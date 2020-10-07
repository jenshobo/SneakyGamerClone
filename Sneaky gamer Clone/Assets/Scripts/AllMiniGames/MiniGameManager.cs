using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    [Header("minigame type")]
    public bool timerWin;

    [Header("variables")]
    public GameObject cameraObject;
    public SpawnEnemies spawnEnemies;
    public CarBehaviour carBehaviour;
    public GameManager manager;
    public Slider timerBar;

    public Vector3 defualtCameraPosition;

    public bool paused = false;

    bool win;

    float timerEnery = 1;
    float time;

    void Update()
    {
        if (Input.GetKey("left shift"))
            paused = true;
        else
            paused = false;

        if (paused)
            return;

        // all mini games
        if (timerEnery <= 0)
        {
            if (timerWin)
            {
                Debug.Log("Minigame is won");
                manager.AddScore(300);
            }
            else
            {
                Debug.Log("Minigame is lost");
                manager.AddScore(0);
            }

            RequestCleanup();
        }

        if (time <= Time.time)
        {
            time = Time.time + .1f;
            timerEnery -= .025f;
            timerBar.value = timerEnery;
        }
    }

    public void SetUpMiniGame(Slider slider, bool timeWin)
    {
        timerEnery = 1;
        timerBar = slider;
        timerWin = timeWin;
    }

    void RequestCleanup()
    {
        cameraObject.transform.position = defualtCameraPosition;
        timerEnery = 1;
        spawnEnemies.CleanUp();
        carBehaviour.CleanUp();
    }

    public void RequestWin(bool i)
    {
        timerWin = i;
    }
}