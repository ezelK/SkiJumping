using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAreaManager : MonoBehaviour
{

    public Vector3 areaCenter;  // Center of the spawn area
    public Vector2 areaSize;    // Size of the spawn area in the Y-axis
    public float spawnInterval = 1f; // Time interval between each spawn

    public GameObject windAreaPrefab; // Prefab of the WindArea object

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning WindArea objects
        InvokeRepeating("SpawnWindArea", spawnInterval, spawnInterval);

    }

    private void SpawnWindArea()
    {
        // Calculate a random position within the spawn area
        Vector3 spawnPosition = new Vector3(410,
            Random.Range(71, 250),
            transform.position.z
        );

        // Instantiate a new WindArea object at the spawn position
        GameObject newWindArea = Instantiate(windAreaPrefab, spawnPosition, Quaternion.identity);
        newWindArea.transform.localEulerAngles = new Vector3(0, 90, 0);

    }
}
