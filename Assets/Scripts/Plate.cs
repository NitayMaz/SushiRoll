using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SushiMove sushiMove = collision.gameObject.GetComponent<SushiMove>();
            sushiMove.ResetPosition();
        }
    }
}
