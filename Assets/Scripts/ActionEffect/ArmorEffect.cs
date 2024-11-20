using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor Effect", menuName = "Card Game/Effects/Armor")]
public class ArmorEffect : ActionEffect
{
    public int armorAmount;

    public override void Apply(Card target)
    {
        Debug.Log($"Applying ArmorEffect: {armorAmount} to {target.name}");
        target.AddArmor(armorAmount);
    }
}
