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
    private Rigidbody2D rb;

    private Vector2 verticalSpeed = Vector2.zero;


    private void Start()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        handleMovement();
    }

    private void handleMovement()
    {
        transform.position += new Vector3(0, verticalSpeed.y * Time.deltaTime, 0); //conveyor belt movement

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
            Move(Vector2.up);
            return;
        }
        if (vertical == -1)
        {
            Move(Vector2.down);
            return;
        }
        if (horizontal == 1)
        {
            Move(Vector2.right);
            return;
        }
        if (horizontal == -1)
        {
            Move(Vector2.left);
            return;
        }
    }

    private void Move(Vector2 direction)
    {
        Vector2 destination = (Vector2)transform.position + direction;

        //0.5 space for the y value so sushi and barrier don't overlap
        Collider2D barrier = Physics2D.OverlapBox(destination,new Vector2(0,0.5f),0f,LayerMask.GetMask("Barrier"));
        Collider2D obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));

        // Prevent any movement if there is a barrier
        if (barrier != null) {
            return;
        }

        //death by obstacle
        if (obstacle != null) {
            ResetPosition();
            return;
        }

        timeSinceLastMove = 0f;
        transform.position = destination;
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
    }

    public void AddVerticalSpeed(float speed)
    {
        verticalSpeed += new Vector2(0, speed);
    }
}
