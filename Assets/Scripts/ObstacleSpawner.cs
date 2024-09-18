using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    private float timer = 0f;

    // Variables to store camera bounds
    private float minY;
    private float maxY;
    private float spawnX;

    void Start()
    {
        // Get the main camera
        Camera cam = Camera.main;

        // Calculate the vertical bounds based on the camera's orthographic size
        minY = cam.transform.position.y - cam.orthographicSize;
        maxY = cam.transform.position.y + cam.orthographicSize;

        // Calculate the horizontal spawn position (right edge of the camera)
        spawnX = cam.transform.position.x + cam.orthographicSize * cam.aspect;

        // Optionally, set the spawner's position (not necessary if it's only used for spawning)
        transform.position = new Vector3(spawnX, cam.transform.position.y, 0);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        // Generate a random Y position within the camera's vertical bounds
        float spawnY = Random.Range(minY, maxY);

        // Create the spawn position
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        // Instantiate the obstacle
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
