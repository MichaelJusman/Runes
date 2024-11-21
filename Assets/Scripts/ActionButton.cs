using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ActionButton : MonoBehaviour
{
    public ActionData action;
    public Button button;
    public Card card;

    [Header("UI Elements")]
    public TMP_Text actionName;
    public GameObject staminaToken;
    public GameObject[] resourceTokens; //0 = Orange, 1 = Green, 2 = Yellow, 3 = Blue, 4 = Grey, 5 = Gold
    public TMP_Text[] resourceText;

    [Header("UI Panels")]
    public GameObject staminaPanel;
    public GameObject resourcePanel;

    private void Start()
    {
        button = GetComponent<Button>();
        Setup();
    }

    private void Update()
    {
        //check if the action can be used. If not then disable the button, if yes, then enable the button
    }

    public void Setup()
    {
        actionName.text = action.actionName;
        EnergyTokens();
        ResourceTokens();
    }

    public void EnergyTokens()
    {
        Debug.Log($"Generating {action.staminaCost} stamina tokens for action: {action.name}");

        // Clear existing tokens
        foreach (Transform child in staminaPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate tokens
        for (int i = 0; i < action.staminaCost; i++)
        {
            Instantiate(staminaToken, staminaPanel.transform);
        }
    }

    public void ResourceTokens()
    {
        for (int i = 0; i < resourceTokens.Length; i++)
        {
            resourceTokens[i].SetActive(false); // Hide all tokens initially
        }

        foreach (var cost in action.resourceCosts)
        {
            int index = (int)cost.color; // Assuming ResourceType is an enum with a matching index
            resourceTokens[index].SetActive(true); // Enable the corresponding token

            // Display the resource amount if it's more than 1
            if (cost.amount > 1)
            {
                resourceText[index].gameObject.SetActive(true);
                resourceText[index].text = cost.amount.ToString();
            }
            else
            {
                resourceText[index].gameObject.SetActive(false); // Hide text for 1
            }
        }
    }

    private bool CanExecuteAction()
    {
        // Check if the owner has enough stamina and resources
        bool hasEnoughStamina = card.stamina >= action.staminaCost;
        bool hasEnoughResources = card.owner.HasEnoughResources(action.resourceCosts);

        return hasEnoughStamina && hasEnoughResources;
    }

    public void OnClick()
    {
        //Execute the action when selected
    }
}
