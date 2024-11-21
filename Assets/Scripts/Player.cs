using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName; // Player's name or identifier
    public Dictionary<ResourceColor, int> currentResources = new Dictionary<ResourceColor, int>();
    public List<Card> cards = new List<Card>(); // Cards owned by the player
    public DiceRoller diceRoller; // Dice roller assigned to this player

    public void AddResources(Dictionary<ResourceColor, int> resources)
    {
        foreach (var resource in resources)
        {
            if (currentResources.ContainsKey(resource.Key))
            {
                currentResources[resource.Key] += resource.Value;
            }
            else
            {
                currentResources[resource.Key] = resource.Value;
            }
        }
    }

    public void SpendResources(ResourceColor color, int amount)
    {
        if (currentResources.ContainsKey(color) && currentResources[color] >= amount)
        {
            currentResources[color] -= amount;
        }
    }

    public bool HasEnoughResources(List<ResourceCost> costs)
    {
        foreach (var cost in costs)
        {
            if (!currentResources.ContainsKey(cost.color) || currentResources[cost.color] < cost.amount)
            {
                return false;
            }
        }
        return true;
    }
}
