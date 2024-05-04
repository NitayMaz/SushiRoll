using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float obstacleSize = 1f;
    private float topEdgeY;
    private float bottomEdgeY;

    private float verticalSpeed;

    private void OnEnable()
    {
        topEdgeY = Camera.main.ViewportToWorldPoint(Vector3.up).y;
        bottomEdgeY = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);

        if (transform.position.y < bottomEdgeY - obstacleSize || transform.position.y > topEdgeY + obstacleSize)
        {
            Destroy(gameObject);
        }
    }

    public void SetVerticalSpeed(float speed)
    {
        verticalSpeed = speed;
    }
}
