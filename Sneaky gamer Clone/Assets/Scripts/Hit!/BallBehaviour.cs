using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public CollisionObject bat;

    public Vector3 ballStartPosition;
    public GameObject ballPrefab;

    public float ballSpeed;

    float[] times = new float[2];
    public GameObject[] balls = new GameObject[2];

    bool toggleOne = true;
    bool toggleTwo = true;

    bool paused;

    void OnEnable()
    {
        ballPrefab.transform.position = ballStartPosition;

        float randomOne = Random.Range(0f, 1f);
        float randomtwo = Random.Range(1.5f, 2.5f);

        times[0] = randomOne + Time.time;
        times[1] = randomtwo + Time.time;
    }

    private void Update()
    {
        // instatiate ball objects
        if (times[0] <= Time.time && toggleOne)
        {
            toggleOne = false;
            balls[0] = Instantiate(ballPrefab);
        }

        if (times[1] <= Time.time && toggleTwo)
        {
            toggleTwo = false;
            balls[1] = Instantiate(ballPrefab);
        }

        if (Input.GetKey("left shift"))
            paused = true;
        else
            paused = false;

        if (paused)
            return;

        // move ball objects (idk why i do it here, just fun i gues)
        foreach (GameObject ball in balls)
        {
            if (ball == null)
                return;

            ball.transform.Translate(-Vector3.forward * Time.deltaTime * ballSpeed);
        }
    }

    public void CleanUp()
    {
        toggleOne = true;
        toggleTwo = true;

        bat.hitCount = 0;

        foreach (GameObject i in balls)
        {
            if (i != null)
            {
                BallDestroy e = i.transform.GetComponent<BallDestroy>();
                e.DestroyThisObject();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ballStartPosition, .2f);
    }
}
