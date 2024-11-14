using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    SingleTarget, // Targets a single enemy or ally
    MultiTarget,  // Targets multiple cards
    Self,         // Targets the card using the action
    NoTarget      // No target required
}

public enum ResourceColor {  Orange, Green, Yellow, Blue, Grey }

[System.Serializable]
public struct ResourceCost
{
    public ResourceColor color;
    public int amount;
}

[CreateAssetMenu(fileName = "New Action", menuName = "Card Game/Action")]
public class ActionData : ScriptableObject
{
    public string actionName;
    public string description; // Optional description for UI
    public TargetType targetType;
    public List<ResourceCost> resourceCosts;
    public List<ActionEffect> effects; // List of effects (e.g., damage, healing)

    public bool CanExecute(Dictionary<ResourceColor, int> availableResources)
    {
        foreach (var cost in resourceCosts)
        {
            // Check if available resources meet the requirement
            if (!availableResources.ContainsKey(cost.color) || availableResources[cost.color] < cost.amount)
            {
                return false;
            }
        }
        return true;
    }
}
