using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int xPosition;
    public int minYPosition;
    public int maxYPosition;

    private void Awake()
    {
        ResetPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.name == "Player1")
            {
                GameManager.instance.Score(1);
            }
            else if (collision.gameObject.name == "Player2")
            {
                GameManager.instance.Score(2);
            }
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        //TEMPORARY: remove the +0.5f once there is a proper sprite pivot
        Vector2 position = new Vector2(xPosition + 0.5f, Random.Range(minYPosition, maxYPosition + 1) + 0.5f);
        transform.position = position;
    }
}
