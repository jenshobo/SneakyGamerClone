using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public MiniGameManager manager;

    public Vector2 minAndMaxPosition;
    public GameObject enemyPrefab;
    public GameObject[] enemies = new GameObject[2];

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            int random = Random.Range(Mathf.RoundToInt(minAndMaxPosition.x), Mathf.RoundToInt(minAndMaxPosition.y));
            enemyPrefab.transform.position = new Vector3(random, (i + 1.5f) * 1.5f);
            enemies[i] = Instantiate(enemyPrefab);
        }
    }

    void Update()
    {
        if (enemies[0] == null && enemies[1] == null)
            manager.RequestWin(true);
    }
}
