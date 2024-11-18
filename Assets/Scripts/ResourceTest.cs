using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{
    public Card testCard;  // Assign a Card with actions in the Inspector
    public DiceRoller diceRoller;

    // Simulated resources available for testing
    public Dictionary<ResourceColor, int> availableResources;

    private void Start()
    {
        //// Initialize resources for testing
        //availableResources = new Dictionary<ResourceColor, int>
        //{
        //    { ResourceColor.Orange, 2 },
        //    { ResourceColor.Green, 1 },
        //    { ResourceColor.Yellow, 3 },
        //    { ResourceColor.Blue, 0 },
        //    { ResourceColor.Grey, 1 }
        //};

        //// Run tests for each action on the test card
        //TestCardActions();

        if (diceRoller == null || testCard == null)
        {
            Debug.LogError("DiceRoller or TestCard not assigned.");
            return;
        }
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
        Dictionary<ResourceColor, int> rolledResources = diceRoller.GetRolledResources();

        Debug.Log($"Testing actions for card: {testCard.cardData.cardName}");

        foreach (var action in testCard.cardData.actions)
        {
            Debug.Log($"Attempting action: {action.actionName}");
            testCard.ExecuteAction(action, rolledResources);

            // Display resources after attempting the action
            DisplayResources(rolledResources);
        }
    }

    private void DisplayResources(Dictionary<ResourceColor, int> resources)
    {
        Debug.Log("Available Resources:");
        foreach (var resource in availableResources)
        {
            Debug.Log($"{resource.Key}: {resource.Value}");
        }
    }
}
