using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class ScoreAndTurnHandler : MonoBehaviour
{
    [SerializeField] GameEventSO gameEvents;
    [SerializeField] TextMeshProUGUI scoreText,totalNoOfAttempsText;
    [SerializeField] TextMeshProUGUI scoreTextPanel,totalNoOfAttempsTextPanel;

    private int continuousHit=0;
    private int score = 0;
    private int baseScoreIncrement = 50;
    private int totalTurn = 0;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = score.ToString();
            scoreTextPanel.text = score.ToString();
        }
    }
    public int TotalTurn
    {
        get { return totalTurn; }
        set
        {
            totalTurn = value;
            totalNoOfAttempsText.text = value.ToString();
            totalNoOfAttempsTextPanel.text=value.ToString();    
        }
    }
    private void Awake()
    {
        gameEvents.OnMatched += GameEvent_OnMatched;
        gameEvents.OnMisMatch += GameEvent_OnMisMatch;
        gameEvents.OnRoundCompleted += GameEvents_OnRoundCompleted;
    }

    private void GameEvents_OnRoundCompleted()
    {

    }
    private void OnDestroy()
    {
        gameEvents.OnMatched -= GameEvent_OnMatched;
        gameEvents.OnMisMatch-= GameEvent_OnMisMatch;
    }
    private void GameEvent_OnMisMatch()
    {
        continuousHit = 0;
        Score -= 20;
        TotalTurn++;
    }
    private void GameEvent_OnMatched()
    {
        continuousHit++;
        Score += continuousHit*baseScoreIncrement;
        TotalTurn++;
    }
}
