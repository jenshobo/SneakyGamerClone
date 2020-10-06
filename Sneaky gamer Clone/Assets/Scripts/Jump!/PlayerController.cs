using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;

    Rigidbody thisRigidbody;
    bool toggle = false;

    bool paused;

    void Start()
    {
        thisRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey("left shift"))
            paused = true;
        else
            paused = false;

        if (paused)
        {
            thisRigidbody.isKinematic = true;
            return;
        }
        else
            thisRigidbody.isKinematic = false;


        if (toggle)
            return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            thisRigidbody.AddForce(Vector3.up * jumpForce);
            toggle = true;
        }
    }
}
