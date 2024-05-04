using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



// We should probably switch to an observer event system once we figure out how to do that.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player1;
    public GameObject player2;

    private int player1Score = 0;
    private int player2Score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("singleton violation");
        }
    }

    public void Score(int scoringPlayer)
    {
        if (scoringPlayer == 1)
        {
            player1Score++;
        }
        else if (scoringPlayer == 2)
        {
            player2Score++;
        }
        else
        {
            Debug.Log("invalid player number");
        }
        Debug.Log(player1Score + "-" + player2Score);
        // add score ui
        player1.GetComponent<SushiMove>().ResetPosition();
        player2.GetComponent<SushiMove>().ResetPosition();
    }
}
