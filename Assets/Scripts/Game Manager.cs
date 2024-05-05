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

    public UIControl uiControl;

    [SerializeField] private int player1Score = 0;
    [SerializeField] private int player2Score = 0;
    [SerializeField] private int player1Position = 0;
    [SerializeField] private int player2Position = 0;

    [SerializeField] private int round = 1;

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
        uiControl.ChangeScore(1,player1Score);
        uiControl.ChangeScore(2,player2Score);
        uiControl.ChangePosition(1,player1Position);
        uiControl.ChangePosition(2,player2Position);
    }

    public void Score(int scoringPlayer)
    {
        //Scores
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

        //Positions
        if (player1Score > player2Score)
        {
            player1Position = 1;
            player2Position = 2;            
        }
        else if (player1Score < player2Score)
        {
            player1Position = 2;
            player2Position = 1;            
        }
        else
        {
            player1Position = 0;
            player2Position = 0;
        }

        round++;

        //UI
        uiControl.ChangeScore(1,player1Score);
        uiControl.ChangeScore(2,player2Score);
        uiControl.ChangePosition(1,player1Position);
        uiControl.ChangePosition(2,player2Position);
        uiControl.ChangeRound(round);
        //
        player1.GetComponent<SushiMove>().ResetPosition();
        player2.GetComponent<SushiMove>().ResetPosition();
    }
}
