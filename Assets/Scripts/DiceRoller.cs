using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public GameObject dicePrefab;
    public GameObject diceHolder;
    public List<Dice> dicePool = new List<Dice>();  // List to hold dice
    private Dictionary<ResourceColor, int> rolledResources;  // Store resource totals after rolling
    public int goldResources = 0;

    private int startingDiceCount = 2;  // Start with 2 dice
    private int currentDiceCount;

    private void Start()
    {
        currentDiceCount = startingDiceCount;
        InitializeDicePool();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RollDice();
            DisplayRolledResources();  // Optional: To see rolled resources in the console
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            currentDiceCount++;
            AddDice();

        }
    }

    private void InitializeDicePool()
    {
        dicePool = new List<Dice>();
        for (int i = 0; i < startingDiceCount; i++)
        {
            AddDice();
        }
    }

    public void RollDice()
    {
        rolledResources = new Dictionary<ResourceColor, int>
        {
            { ResourceColor.Orange, 0 },
            { ResourceColor.Green, 0 },
            { ResourceColor.Yellow, 0 },
            { ResourceColor.Blue, 0 },
            { ResourceColor.Grey, 0 }
        };

        // Roll each die in the pool and tally results
        foreach (var die in dicePool)
        {
            DiceFace face = die.Roll();
            AddResourceFromFace(face);
        }
    }

    private ResourceColor MapFaceToColor(DiceFace face)
    {
        // Map each DiceFace to a corresponding ResourceColor
        switch (face)
        {
            case DiceFace.Orange: 
                return ResourceColor.Orange;
            case DiceFace.Green: 
                return ResourceColor.Green;
            case DiceFace.Yellow: 
                return ResourceColor.Yellow;
            case DiceFace.Blue: 
                return ResourceColor.Blue;
            case DiceFace.Grey: 
                return ResourceColor.Grey;
            case DiceFace.Gold: 
                return ResourceColor.Gold;
            default: return ResourceColor.Grey;  // Default or wildcard if needed
        }
    }

    void AddResourceFromFace(DiceFace face)
    {
        switch (face)
        {
            case DiceFace.Orange:
                rolledResources[ResourceColor.Orange]++;
                break;
            case DiceFace.Green:
                rolledResources[ResourceColor.Green]++;
                break;
            case DiceFace.Yellow:
                rolledResources[ResourceColor.Yellow]++;
                break;
            case DiceFace.Blue:
                rolledResources[ResourceColor.Blue]++;
                break;
            case DiceFace.Grey:
                rolledResources[ResourceColor.Grey] += 2;  // Grey adds +2
                break;
            case DiceFace.Gold:
                goldResources += 2;  // Gold is persistent and accumulates
                break;
        }
    }

    private void AddDice()
    {
        GameObject diceObject = Instantiate(dicePrefab, diceHolder.transform);  // Instantiate from prefab
        Dice newDie = diceObject.GetComponent<Dice>();
        if (newDie != null)
        {
            dicePool.Add(newDie);  // Add the new Dice instance to the pool
            Debug.Log("Added one more die. Current dice count: " + currentDiceCount);
        }
    }

    private void DisplayRolledResources()
    {
        Debug.Log("Rolled Resources:");
        foreach (var resource in rolledResources)
        {
            Debug.Log($"{resource.Key}: {resource.Value}");
        }
        Debug.Log($"Gold Resources (Persistent): {goldResources}");
    }

    public Dictionary<ResourceColor, int> GetRolledResources()
    {
        // Combine rolled resources with persistent gold
        var currentResources = new Dictionary<ResourceColor, int>(rolledResources)
        {
            { ResourceColor.Gold, goldResources }  // Add gold to the total
        };
        return currentResources;
    }

    public int SpendGold(int amount)
    {
        if (goldResources >= amount)
        {
            goldResources -= amount;
            return amount;
        }
        return 0;  // Not enough gold to spend
    }
}
