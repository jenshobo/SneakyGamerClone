using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public bool idle;

    public AudioSource enemySoundSource;
    public Animation enemyAnimation;
    public Text statusText;

    public float maxWait;
    public float minWait;
    public float waitPerMove;

    static float startTime = 0;
    static float endTime = 0;
    static bool stop = false;
    static bool isWatching;
    static bool animationPlaying;

    public bool watching;

    private void Start()
    {
        if (isWatching)
            statusText.text = "Enemy Status: Watching";
        else
            statusText.text = "Enemy Status: Away";

        if (animationPlaying)
            enemyAnimation.Play();
    }

    private void Update()
    {
        animationPlaying = enemyAnimation.isPlaying;
        watching = isWatching;

        // getting random time to start StartMove and getting a time (waitPerMove after start) to start EndMove
        if (startTime <= Time.time && stop)
        {
            endTime = Time.time + waitPerMove;
            stop = false;

            enemyAnimation.Play();
        }
        else if (endTime <= Time.time)
        {
            float random = Random.Range(minWait, maxWait);
            startTime = Time.time + random;
            endTime = Mathf.Infinity;
            stop = true;

            EndMove();
        }
    }

    void StartMove()
    {
        enemySoundSource.Play();
    }

    void SetActive()
    {
        statusText.text = "Enemy Status: Watching";
        isWatching = true;
    }

    void EndMove()
    {
        statusText.text = "Enemy Status: Away";
        isWatching = false;
    }
}
