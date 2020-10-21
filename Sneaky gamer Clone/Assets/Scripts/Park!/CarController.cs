using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject startPosition;
    public float speed;
    public MiniGameManager manager;

    bool broken = false;
    bool paused;

    void OnEnable()
    {
        gameObject.transform.position = startPosition.transform.position; gameObject.transform.rotation = startPosition.transform.rotation;
        broken = false;
    }

    void Update()
    {
        if (Input.GetKey("left shift"))
            paused = true;
        else
            paused = false;

        if (broken || paused)
            return;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.down);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Finish")
        {
            manager.RequestWin(true);
            broken = true;
        }

        if (collision.transform.tag == "Car")
        {
            broken = true;
        }
    }
}
