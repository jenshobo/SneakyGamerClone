using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    public Animation batSwing;
    public bool win = false;

    int hitCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            batSwing.Play();

        if (hitCount >= 2)
            win = true;

        Debug.Log(hitCount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.rotation = new Quaternion(90, 0, 0, 0);
        SphereCollider collider = collision.transform.GetComponent<SphereCollider>();
        collider.enabled = false;

        hitCount++;
    }
}
