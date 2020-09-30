using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public bool idle;

    public Text statusText;

    public float maxWait;
    public float minWait;
    public float waitPerMove;

    static float startTime = 0;
    static float endTime = 0;
    static bool stop = false;
    static bool isWatching;

    private void Start()
    {
        if (isWatching)
            statusText.text = "Enemy Status: Watching";
        else
            statusText.text = "Enemy Status: Away";
    }

    private void Update()
    {
        // getting random time to start StartMove and getting a time (waitPerMove after start) to start EndMove
        if (startTime <= Time.time && stop)
        {
            endTime = Time.time + waitPerMove;
            stop = false;

            StartMove();
        }
        else if (endTime <= Time.time)
        {
            float random = Random.Range(minWait, maxWait);
            startTime = Time.time + random;
            endTime = Mathf.Infinity;
            stop = true;

            //Debug.Log(random);

            EndMove();
        }
    }

    void StartMove()
    {
        // enemy has multiple positions to come from do this with an (int)random.range
        // get something like an animation (with function call) to make a sound here and then later iswatching = true
        statusText.text = "Enemy Status: Watching";
        isWatching = true;
    }

    void EndMove()
    {
        // just remove the enemy for now
        statusText.text = "Enemy Status: Away";
        isWatching = false;
    }
}
