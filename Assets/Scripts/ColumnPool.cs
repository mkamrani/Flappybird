using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    [SerializeField] int columnPoolSize = 5;
    [SerializeField] GameObject columnPrefab;
    [SerializeField] float spawnRate = 4;
    [SerializeField] float columnMin = -1;
    [SerializeField] float columnMax = 3.5f;
    [SerializeField] float spawnXPosition = 10f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f); // Position the columns off screen
    private float timeSinceLastSpawned;
    private int currentColumn = 0;

    // Use this for initialization
	void Start () {

	    columns = new GameObject[columnPoolSize];
	    for (int i = 0; i < columnPoolSize; i++)
	    {
	        columns[i] = (GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timeSinceLastSpawned += Time.deltaTime;
	    if (!GameControl.instance.GameOver && timeSinceLastSpawned >= spawnRate)
	    {
	        timeSinceLastSpawned = 0;
	        var spawnYPosition = Random.Range(columnMin, columnMax);
	        columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
	        currentColumn++;
	        if (currentColumn >= columnPoolSize)
	        {
	            currentColumn = 0;
	        }
	    }

	}
}
