using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public GameObject dicePrefab;
    public GameObject diceHolder;
    private List<Dice> dicePool = new List<Dice>();  // List to hold dice
    private Dictionary<ResourceColor, int> rolledResources;  // Store resource totals after rolling

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
            //RollDice();
            DisplayRolledResources();  // Optional: To see rolled resources in the console
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
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
        rolledResources = new Dictionary<ResourceColor, int>();

        // Roll each die in the pool and tally results
        foreach (var die in dicePool)
        {
            DiceFace face = die.Roll();
            ResourceColor color = MapFaceToColor(face);

            if (rolledResources.ContainsKey(color))
                rolledResources[color]++;
            else
                rolledResources[color] = 1;
        }
    }

    private ResourceColor MapFaceToColor(DiceFace face)
    {
        // Map each DiceFace to a corresponding ResourceColor
        switch (face)
        {
            case DiceFace.Orange: return ResourceColor.Orange;
            case DiceFace.Green: return ResourceColor.Green;
            case DiceFace.Yellow: return ResourceColor.Yellow;
            case DiceFace.Blue: return ResourceColor.Blue;
            case DiceFace.Grey: return ResourceColor.Grey;
            default: return ResourceColor.Grey;  // Default or wildcard if needed
        }
    }

    private void AddDice()
    {
        GameObject diceObject = Instantiate(dicePrefab, diceHolder.transform);  // Instantiate from prefab
        Dice newDie = diceObject.GetComponent<Dice>();
        if (newDie != null)
        {
            dicePool.Add(newDie);  // Add the new Dice instance to the pool
            currentDiceCount++;
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
    }

    public Dictionary<ResourceColor, int> GetRolledResources()
    {
        return rolledResources;
    }
}
