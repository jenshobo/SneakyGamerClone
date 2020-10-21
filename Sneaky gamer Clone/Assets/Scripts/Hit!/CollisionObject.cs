using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    public MiniGameManager manager;

    public Animation batSwing;

    public int hitCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            batSwing.Play();

        if (hitCount >= 2)
            manager.RequestWin(true);

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
