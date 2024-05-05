using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public GameObject[] playersScore;
    public GameObject[] playersPlace;
    public Sprite[] positionSprites;
    public Sprite[] scoreSprites;

    public TMP_Text roundText;
    
    private void Awake()
    {
                
    }

    public void ChangePosition(int playerID,int position)
    {
        playersPlace[playerID-1].GetComponent<Image>().sprite = positionSprites[position]; 
    }

    public void ChangeScore(int playerID,int score)
    {
        playersScore[playerID-1].GetComponent<Image>().sprite = scoreSprites[score];
    }

    public void ChangeRound(int round)
    {
        roundText.text = "Round "+ round;
    }
}
