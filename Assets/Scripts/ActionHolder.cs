using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHolder : MonoBehaviour
{
    public CardData cardData; // Reference to the CardData with the actions
    public GameObject actionButtonPrefab; // The prefab for the action button
    public Transform actionButtonParent; // The parent object where buttons will be instantiated

    private void Start()
    {
        Card thisCard = GetComponent<Card>();
        cardData = thisCard.cardData;
        
        CreateActionButtons();
    }

    public void CreateActionButtons()
    {
        //// Clear existing buttons (optional, in case of refresh or re-setup)
        //foreach (Transform child in actionButtonParent)
        //{
        //    Destroy(child.gameObject);
        //}

        // Loop through all actions in the CardData and create buttons
        foreach (var action in cardData.actions)
        {
            GameObject buttonObject = Instantiate(actionButtonPrefab, actionButtonParent); // Instantiate prefab
            ActionButton actionButton = buttonObject.GetComponent<ActionButton>();

            // Assign the action data and setup the button
            actionButton.action = action;
            actionButton.Setup();
        }
    }
}
