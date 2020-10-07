using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public int numberOfBoxes;
    public Vector2 minAndMaxPositionX;
    public Vector2 minAndMaxPositionY;

    public GameObject boxPrefab;

    void Start()
    {
        for (int i = 0; i <= numberOfBoxes; i++)
        {
            float randomX = Random.Range(minAndMaxPositionX.x, minAndMaxPositionX.y);
            float randomY = Random.Range(minAndMaxPositionY.x, minAndMaxPositionY.y);

            boxPrefab.transform.position = new Vector3(randomX, randomY);

            Instantiate(boxPrefab);
        }
    }
}
