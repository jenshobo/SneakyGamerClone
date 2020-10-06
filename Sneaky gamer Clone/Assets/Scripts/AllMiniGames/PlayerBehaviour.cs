using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;

    public bool twoD;

    bool paused;

    void Update()
    {
        if (Input.GetKey("left shift"))
            paused = true;
        else
            paused = false;

        if (paused)
            return;

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (twoD)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, Vector3.up, out hit))
                {
                    EnemyBehaviour enemy = hit.transform.GetComponent<EnemyBehaviour>();
                    enemy.DestroyThisObject();
                }
            }
        }
        else
        {
            if (Input.GetKey("w"))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed);
            }
        }
    }
}
