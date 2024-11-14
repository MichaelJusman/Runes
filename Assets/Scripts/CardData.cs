using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardData", menuName = "Card Game/Card Data")]
public class CardData : ScriptableObject
{
    public string cardName;
    public int health;
    public int armor;
    public int stamina;
    public Sprite artwork;
    public Rarity rarity;
    public List<CardType> types;
    public List<ActionData> actions;
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Godlike
}

public enum CardType
{
    //Region
    ZyZik,
    Davon,
    KyrBottsun,
    Chogal,
    Aum,
    Hykross,
    Kurcheweres,

    //Race
    Human,
    Elf,
    Mere,
    Bewilder,
    Vampire,

    //Occupation
    BountyHunter,
    Priest,
    Druid,
    Knight,
    
    //Patron God
    Arum,
    MorKi,
    Paraxix,
    Tietzobuchol
}
