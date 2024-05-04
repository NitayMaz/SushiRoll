using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ConveyorMove : MonoBehaviour
{
    private Vector2 direction;
    private float speed;
    private int size;

    private Vector3 topEdge;
    private Vector3 bottomEdge;

    private GameObject obstaclePrefab;
    private float obstacleSpawnChance;

    private void Start()
    {
        ConveyorProperties properties = GetComponentInParent<ConveyorProperties>();
        direction = properties.direction;
        speed = properties.speed;
        size = properties.size;
        topEdge = Camera.main.ViewportToWorldPoint(Vector3.up);
        bottomEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        obstaclePrefab = properties.obstaclePrefab;
        obstacleSpawnChance = properties.obstacleSpawnChance;
    }

    private void Update()
    {
        // Check if the object is past the top edge of the screen
        if (direction.y > 0 && (transform.position.y - size) > topEdge.y) {
            transform.position = new Vector3(transform.position.x,bottomEdge.y - size, transform.position.z);
            SpawnObstacle();
        }
        // Check if the object is past the bottom edge of the screen
        else if (direction.y < 0 && (transform.position.y + size) < bottomEdge.y) {
            transform.position = new Vector3(transform.position.x,topEdge.y + size, transform.position.z);
            SpawnObstacle();
        }
        // Move the object
        else {
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }

    private void SpawnObstacle()
    {
        if(transform.childCount > 0) // destroy previous obstacles
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        // Spawn a new obstacle sometimes
        if (Random.value < obstacleSpawnChance)
        {
            GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            obstacle.transform.parent = transform;
        }
    }

}
