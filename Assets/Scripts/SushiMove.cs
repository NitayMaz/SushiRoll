using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiMove : MonoBehaviour
{
    public string verticalAxis;
    public string horizontalAxis;

    [Tooltip("so collission detection works from the center of the sprite, not the pivot")]
    public Vector2 pivotToCenterOffset = new Vector2(0.5f, 0.5f);

    public float movementDelay = 0.3f;
    private float timeSinceLastMove = 0f;

    private Vector2 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        handleMovement();
    }

    private void handleMovement()
    {
        //notes: GetAxisRaw returns -1, 0, or 1 for keyboard which is closer to getkeydown than getaxis(though it will still get that value for multiple frames - hence the delay)
        //the switch like structre prevents diagonal movement.

        //first, check if enough time has passed since the last move
        timeSinceLastMove += Time.deltaTime;
        if (timeSinceLastMove < movementDelay)
        {
            return;
        }

        float vertical = Input.GetAxisRaw(verticalAxis);
        float horizontal = Input.GetAxisRaw(horizontalAxis);
        if (vertical == 1)
        {
            Move(Vector3.up);
            return;
        }
        if (vertical == -1)
        {
            Move(Vector3.down);
            return;
        }
        if (horizontal == 1)
        {
            Move(Vector3.right);
            return;
        }
        if (horizontal == -1)
        {
            Move(Vector3.left);
            return;
        }
    }

    private void Move(Vector3 direction)
    {
        Vector2 destination = transform.position + direction;
        Vector2 objectCenter = destination + pivotToCenterOffset;
        //0.5 for the y value so sushi and barrier don't overlap
        Collider2D barrier = Physics2D.OverlapBox(objectCenter,new Vector2(0,0.5f),0f,LayerMask.GetMask("Barrier"));
        //Collider2D obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));
        Collider2D conveyor = Physics2D.OverlapBox(objectCenter, Vector2.zero, 0f, LayerMask.GetMask("Conveyor"));

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
        timeSinceLastMove = 0f;
        destination.y = Mathf.Round(destination.y); // specifically for the case of going off a conveyor, might be an better way to handle this
        transform.position = destination;
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
        transform.SetParent(null); // in case the sushi was attached to a conveyor
    }
}
