using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public float speed;

    public Vector3[] movePositions = new Vector3[4];
    public Vector3 movingToPosition;

    void Start()
    {
        GetRandomPoint();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, movingToPosition) <= 1)
            GetRandomPoint();

        Vector3 dir = (movingToPosition - transform.position).normalized;
        transform.Translate(dir * Time.deltaTime * speed);
    }

    void GetRandomPoint()
    {
        int random = Random.Range(0, movePositions.Length);
        movingToPosition = movePositions[random];
    }

    private void OnDrawGizmos()
    {
        foreach (Vector3 V in movePositions)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(V, .2f);
        }
    }
}
