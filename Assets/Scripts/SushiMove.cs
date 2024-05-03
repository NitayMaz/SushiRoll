using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiMove : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Vector3.down);
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 destination = transform.position + direction;
        Collider2D barrier = Physics2D.OverlapBox(destination,Vector2.zero,0f,LayerMask.GetMask("Barrier"));
        Collider2D obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));
        Collider2D conveyor = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Conveyor"));

        // Prevent any movement if there is a barrier
        if (barrier != null) {
            return;
        }

        // Attach/detach sushi from the conveyor
        if (conveyor != null) {
            transform.SetParent(conveyor.transform);
        } else {
            transform.SetParent(null);
        }

        transform.position = destination;
    }
}
