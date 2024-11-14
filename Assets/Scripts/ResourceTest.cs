using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{
    public Card testCard;  // Assign a Card with actions in the Inspector

    // Simulated resources available for testing
    public Dictionary<ResourceColor, int> availableResources;

    private void Start()
    {
        // Initialize resources for testing
        availableResources = new Dictionary<ResourceColor, int>
        {
            { ResourceColor.Orange, 2 },
            { ResourceColor.Green, 1 },
            { ResourceColor.Yellow, 3 },
            { ResourceColor.Blue, 0 },
            { ResourceColor.Grey, 1 }
        };

        // Run tests for each action on the test card
        TestCardActions();
    }

    private void TestCardActions()
    {
        Debug.Log($"Testing actions for card: {testCard.cardData.cardName}");

        foreach (var action in testCard.cardData.actions)
        {
            Debug.Log($"Attempting action: {action.actionName}");
            testCard.ExecuteAction(action, availableResources);

            // Display remaining resources after attempting the action
            DisplayResources();
        }
    }

    private void DisplayResources()
    {
        Debug.Log("Available Resources:");
        foreach (var resource in availableResources)
        {
            Debug.Log($"{resource.Key}: {resource.Value}");
        }
    }
}
