using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    [Header("minigame type")]
    public bool timerWin;
    public bool shoot;

    [Header("variables")]
    public GameObject enemyPrefab;
    public Slider timerBar;

    public Vector2 minAndMaxPosition;

    public bool paused = false;

    float timerEnery = 1;
    float time;
    GameObject[] enemies = new GameObject[2];

    void Start()
    {
        if (shoot)
        {
            for (int i = 0; i < 2; i++)
            {
                int random = Random.Range(Mathf.RoundToInt(minAndMaxPosition.x), Mathf.RoundToInt(minAndMaxPosition.y));
                enemyPrefab.transform.position = new Vector3(random, (i + 1.5f) * 1.5f);
                enemies[i] = Instantiate(enemyPrefab);
            }
        }
    }

    void Update()
    {
        if (paused)
            return;

        if (shoot)
        {
            if (enemies[0] == null && enemies[1] == null)
            {
                Debug.Log("minigame is done, you won");
                // game is done, return with x amount points
            }
        }

        // all mini games
        if (timerEnery <= 0)
        {
            if (timerWin)
            {
                Debug.Log("minigame is over, you won");
                // game is done, return with x amount points
            }
            else
            {
                Debug.Log("minigame is over, you lost");
                // game is done, return with 0 points
            }

        }

        if (time <= Time.time)
        {
            time = Time.time + .1f;
            timerEnery -= .025f;
            timerBar.value = timerEnery;
        }
    }
}