using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public Vector2 minAndMaxPosition;

    bool toggle = true;

    void Update()
    {
        // for the micro game Shoot!

        if (toggle)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        else
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (transform.position.x <= minAndMaxPosition.x)
            toggle = false;
        else if (transform.position.x >= minAndMaxPosition.y)
            toggle = true;
    }

    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
}
