using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // public float obstacleSize = 1f;
    // private float topEdgeY;
    // private float bottomEdgeY;

    private float verticalSpeed;

    private void OnEnable()
    {
        // topEdgeY = Camera.main.ViewportToWorldPoint(Vector3.up).y;
        // bottomEdgeY = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);

        //added die function instead of this calculation to fit conveyors on a section of the screen
        // if (transform.position.y < bottomEdgeY - obstacleSize || transform.position.y > topEdgeY + obstacleSize)
        // {
        //     Destroy(gameObject);
        // }
    }

    public void SetVerticalSpeed(float speed)
    {
        verticalSpeed = speed;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
