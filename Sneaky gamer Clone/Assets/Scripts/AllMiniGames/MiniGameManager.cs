using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    [Header("minigame type")]
    public bool timerWin;
    public bool lightMiniGame;

    [Header("variables")]
    public GameManager manager;
    public SpawnEnemies shootEnemies;
    public Slider timerBar;

    public bool paused = false;

    bool win;

    float timerEnery = 1;
    float time;

    void Update()
    {
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
        }

        if (time <= Time.time)
        {
            time = Time.time + .1f;
            timerEnery -= .025f;
            timerBar.value = timerEnery;
        }
    }

    public void RequestWin(bool i)
    {
        timerWin = i;
    }
}