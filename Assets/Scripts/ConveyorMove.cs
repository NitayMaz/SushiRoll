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

    private void Start()
    {
        ConveyorProperties properties = GetComponentInParent<ConveyorProperties>();
        direction = properties.direction;
        speed = properties.speed;
        size = properties.size;
        topEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        bottomEdge = Camera.main.ViewportToWorldPoint(Vector3.up);
    }

    private void Update()
    {
        // Check if the object is past the right edge of the screen
        if (direction.y > 0 && (transform.position.y - size) > bottomEdge.y) {
            transform.position = new Vector3(transform.position.x,topEdge.y - size, transform.position.z);
        }
        // Check if the object is past the left edge of the screen
        else if (direction.y < 0 && (transform.position.y + size) < topEdge.y) {
            transform.position = new Vector3(transform.position.x,bottomEdge.y + size, transform.position.z);
        }
        // Move the object
        else {
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }

}
