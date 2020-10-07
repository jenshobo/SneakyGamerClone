using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public MiniGameManager manager;

    public Vector2 minAndMaxPosition;
    public float speed;

    bool toggle = false;
    bool paused;
    float boxPosition = 1.1f;

    void Update()
    {
        if (Input.GetKey("left shift"))
            paused = true;
        else
            paused = false;

        if (paused)
            return;

        if (toggle)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            if (transform.position.y >= minAndMaxPosition.y)
                toggle = false;
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            if (transform.position.y <= minAndMaxPosition.x)
                toggle = true;
        }

        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -Vector3.right, out hit))
            {
                hit.transform.position = new Vector3(transform.position.x + boxPosition, transform.position.y);
                hit.transform.SetParent(this.gameObject.transform);

                boxPosition += 1.1f;
            }
        }

        if (boxPosition >= 4.4f)
        {
            manager.RequestWin(true);
        }
    }
}
