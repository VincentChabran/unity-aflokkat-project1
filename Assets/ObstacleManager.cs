using UnityEngine;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private List<GameObject> obstacles = new List<GameObject>();

    private float spawnTimer = 0f;

    void FixedUpdate()
    {
        spawnTimer += Time.fixedDeltaTime;

        if (spawnTimer >= 2.5f)
        {
            // Choisir aléatoirement entre le haut et le bas
            bool versLeHaut = Random.value > 0.5f;
            float yPosition = versLeHaut ? 5f : -3f;

            Vector3 spawnPosition = new Vector3(transform.position.x, yPosition, transform.position.z);

            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // Si c'est vers le haut, on retourne le sprite verticalement
            if (versLeHaut)
            {
                newObstacle.transform.localScale = new Vector3(
                    newObstacle.transform.localScale.x,
                    -Mathf.Abs(newObstacle.transform.localScale.y),
                    newObstacle.transform.localScale.z
                );
            }

            obstacles.Add(newObstacle);
            spawnTimer = 0f;
        }
    }


    void Update()
    {
        for (int i = obstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = obstacles[i];
            if (obstacle != null)
            {
                obstacle.transform.position += Vector3.left * Time.deltaTime * 5f;

                if (obstacle.transform.position.x < -10f)
                {
                    Destroy(obstacle);
                    obstacles.RemoveAt(i);
                }
            }
            else
            {
                obstacles.RemoveAt(i);
            }
        }
    }
}
