using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPosition;

    public float jumpForce;

    Rigidbody thisRigidbody;
    bool toggle = false;

    bool paused;

    void OnEnable()
    {
        thisRigidbody = this.gameObject.GetComponent<Rigidbody>();
        gameObject.transform.position = startPosition;
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

    private void OnCollisionEnter(Collision collision)
    {
        toggle = false;
    }
}
