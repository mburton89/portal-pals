using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarnholeManager : MonoBehaviour
{
    public bool isAlternatingTurns;
    public bool isPlayerOnesTurn;
    public bool player1GoesFirst;
    public GameObject player1Indicator;
    public GameObject player2Indicator;
    private int _turnsCompletedInRounds;

    public int p1RoundScore;
    public int p2RoundScore;
    public TextMeshProUGUI p1RoundScoreText;
    public TextMeshProUGUI p2RoundScoreText;

    public int p1TotalScore;
    public int p2TotalScore;
    public TextMeshProUGUI p1TotalScoreText;
    public TextMeshProUGUI p2TotalScoreText;

    void Start()
    {
        Reset();
    }

    public void AwardPointsForRound(bool isPlayer1, int pointsToAward)
    {
        if (isPlayer1) 
        {
            if (p2RoundScore == 0)
            {
                p1RoundScore += pointsToAward;
            }
            else if (p2RoundScore >= pointsToAward)
            {
                p2RoundScore -= pointsToAward;
            }
            else if (p2RoundScore > 0 && p2RoundScore < pointsToAward) 
            {
                p1RoundScore = p1RoundScore + pointsToAward - p2RoundScore;
                p2RoundScore = 0;
            }
        }
        else
        {
            if (p1RoundScore == 0)
            {
                p2RoundScore += pointsToAward;
            }
            else if (p1RoundScore >= pointsToAward)
            {
                p1RoundScore -= pointsToAward;
            }
            else if (p1RoundScore > 0 && p1RoundScore < pointsToAward)
            {
                p2RoundScore = p2RoundScore + pointsToAward - p1RoundScore;
                p1RoundScore = 0;
            }
        }
        DetermineNextPlayer();
        UpdateUI();
    }

    public void DetermineNextPlayer()
    {
        _turnsCompletedInRounds++;
        if (_turnsCompletedInRounds < 8)
        {
            if (isAlternatingTurns)
            {
                isPlayerOnesTurn = !isPlayerOnesTurn;
            }
            else
            {
                if (_turnsCompletedInRounds < 4)
                {
                    if (player1GoesFirst)
                    {
                        isPlayerOnesTurn = true;
                    }
                    else
                    {
                        isPlayerOnesTurn = false;
                    }
                }
                else
                {
                    if (player1GoesFirst)
                    {
                        isPlayerOnesTurn = false;
                    }
                    else
                    {
                        isPlayerOnesTurn = true;
                    }
                }
            }
        }
        else
        {
            CompleteRound();
            _turnsCompletedInRounds = 0;
        }
    }

    public void CompleteRound()
    {
        if (p1RoundScore > p2RoundScore)
        {
            player1GoesFirst = true;
            isPlayerOnesTurn = true;
        }
        else if (p1RoundScore < p2RoundScore)
        {
            player1GoesFirst = false;
            isPlayerOnesTurn = false;
        }
        p1TotalScore += p1RoundScore;
        p2TotalScore += p2RoundScore;
        p1RoundScore = 0;
        p2RoundScore = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        p1RoundScoreText.SetText(p1RoundScore.ToString());
        p2RoundScoreText.SetText(p2RoundScore.ToString());
        p1TotalScoreText.SetText(p1RoundScore.ToString());
        p2TotalScoreText.SetText(p2RoundScore.ToString());
        if (isPlayerOnesTurn)
        {
            player1Indicator.SetActive(true);
            player2Indicator.SetActive(false);
        }
        else
        {
            player1Indicator.SetActive(false);
            player2Indicator.SetActive(true);
        }
    }

    public void Reset()
    {
        isPlayerOnesTurn = true;
        player1GoesFirst = true;
        p1RoundScore = 0;
        p2RoundScore = 0;
        p1TotalScore = 0;
        p2TotalScore = 0;
        UpdateUI();
    }
}
