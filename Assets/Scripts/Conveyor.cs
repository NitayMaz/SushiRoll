using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;

    public Vector2 obstacleSpawnOffset;
    public GameObject[] obstaclePrefabs;
    public float minTimeBetweenObstacles;
    public float maxTimeBetweenObstacles;

    private float timeToNextObstacle;

    private void Start()
    {
        timeToNextObstacle = Random.Range(minTimeBetweenObstacles, maxTimeBetweenObstacles);
    }

    private void Update()
    {
        timeToNextObstacle -= Time.deltaTime;
        if (timeToNextObstacle <= 0)
        {
            timeToNextObstacle = Random.Range(minTimeBetweenObstacles, maxTimeBetweenObstacles);
            int obstacleID = Random.Range(0,obstaclePrefabs.Length);
            GameObject newObstacle = Instantiate(obstaclePrefabs[obstacleID], (Vector2)transform.position + obstacleSpawnOffset, Quaternion.identity);
            newObstacle.GetComponent<Obstacle>().SetVerticalSpeed(speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player entered conveyor");
            SushiMove sushiMove = collision.gameObject.GetComponent<SushiMove>();
            sushiMove.AddVerticalSpeed(speed);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exited conveyor");
            SushiMove sushiMove = collision.gameObject.GetComponent<SushiMove>();
            sushiMove.AddVerticalSpeed(-speed);
        }
    }
}
