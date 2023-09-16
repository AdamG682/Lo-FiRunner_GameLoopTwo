using UnityEngine;

public class GroundTile: MonoBehaviour
{
    public GameObject obstaclePrefab;
    GroundSpawner groundSpawner;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 1);
    }

    void SpawnObstacle()
    {
        //random point that spawns the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawing the obstacle
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
