using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public Vector3 startPosition;

    public MiniGameManager manager;

    float speed;

    bool paused;

    void OnEnable()
    {
        speed = Random.Range(7.5f, 15f);
    }

    void Update()
    {
        if (Input.GetKey("left shift"))
            paused = true;
        else
            paused = false;

        if (paused)
            return;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void CleanUp()
    {
        transform.position = startPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            manager.RequestWin(false);
        }
    }
}
