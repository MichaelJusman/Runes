using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal Effect", menuName = "Card Game/Effects/Heal")]
public class HealEffect : ActionEffect
{
    public int healAmount;

    public override void Apply(Card target)
    {
        Debug.Log($"Applying HealEffect: {healAmount} to {target.name}");
        target.Heal(healAmount);
    }
}
