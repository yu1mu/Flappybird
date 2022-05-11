using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);

    private GameObject[] columns;
    public int columnPoolSize = 5;

    private float timeSinceLastSpawned;
    public float spawnRate = 4.0f;
    public float columnMin = -1.0f;
    public float columnMax = 3.5f;
    private float spawnXPosition = 10.0f;
    private int currentColumn = 0;

    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);

        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(GameControl.instance.gameOver == false && timeSinceLastSpawned > spawnRate)
        {
            timeSinceLastSpawned = 0.0f;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize) currentColumn = 0;
        }
    }
}
