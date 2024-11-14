using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum Phase { RollPhase, ActionPhase, EndPhase }
    public Phase currentPhase = Phase.RollPhase;
    public int playerTurn = 1;

    public void NextPhase()
    {
        switch (currentPhase)
        {
            case Phase.RollPhase:
                // Players roll their dice
                RollDice();
                currentPhase = Phase.ActionPhase;
                break;
            case Phase.ActionPhase:
                // Players take turns in action phase
                ExecuteActions();
                currentPhase = Phase.EndPhase;
                break;
            case Phase.EndPhase:
                // End round and reset for the next round
                ResetForNextRound();
                break;
        }
    }

    private void RollDice()
    {
        // Code to handle dice rolling for both players
        Debug.Log("Rolling dice for players.");
    }

    private void ExecuteActions()
    {
        Debug.Log("Players are taking actions.");
    }

    private void ResetForNextRound()
    {
        Debug.Log("Resetting for next round.");
        playerTurn = (playerTurn == 1) ? 2 : 1;
        currentPhase = Phase.RollPhase;
    }
}
