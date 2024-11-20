using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{
    public Card testCard;  // Assign a Card with actions in the Inspector
    public DiceRoller diceRoller;

    private void Start()
    {
        //if (Input.GetKeyDown(KeyCode.E))  // Press E to test actions
        //{
        //    TestCardActions();
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //diceRoller.RollDice();  // Roll the dice and update resources
            TestCardActions();      // Attempt to execute actions with rolled resources
        }
    }


    private void TestCardActions()
    {
        var rolledResources = diceRoller.GetRolledResources();

        Debug.Log($"Testing actions for card: {testCard.cardData.cardName}");

        foreach (var action in testCard.cardData.actions)
        {
            Debug.Log($"Attempting action: {action.actionName}");
            testCard.ExecuteAction(action, rolledResources);
        }
    }

}
