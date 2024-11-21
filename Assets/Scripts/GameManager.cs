using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player1;
    public Player player2;

    public void Start()
    {
        // Initialize players
        player1 = new Player { playerName = "Player 1" };
        player2 = new Player { playerName = "Player 2" };

        // Assign dice rollers or other player-specific components
        player1.diceRoller = CreateDiceRoller();
        player2.diceRoller = CreateDiceRoller();

        // Assign cards to players
        //SetupPlayerCards(player1);
        //SetupPlayerCards(player2);
    }

    //private void SetupPlayerCards(Player player)
    //{
    //    foreach (var cardData in GetPlayerCardData(player)) // Retrieve player-specific card data
    //    {
    //        Card card = Instantiate(cardPrefab); // Create card instance
    //        card.Initialize(player); // Assign ownership
    //        player.cards.Add(card);
    //    }
    //}

    private DiceRoller CreateDiceRoller()
    {
        // Instantiate or assign a DiceRoller for the player
        GameObject diceRollerObject = new GameObject("DiceRoller");
        return diceRollerObject.AddComponent<DiceRoller>();
    }
}
