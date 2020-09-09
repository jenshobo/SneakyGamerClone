﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Text statusText;

    public float maxWait;
    public float minWait;
    public float waitPerMove;

    public bool isWatching; // is for GameManager

    float startTime = 0;
    float endTime = 0;

    bool stop = false;

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

            Debug.Log(random);

            EndMove();
        }
    }

    void StartMove()
    {
        // enemy has multiple positions to come from do this with an (int)random.range
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
