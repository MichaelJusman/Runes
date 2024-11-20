using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Effect", menuName = "Card Game/Effects/Damage")]
public class DamageEffect : ActionEffect
{
    public int damageAmount;

    public override void Apply(Card target)
    {
        target.TakeDamage(damageAmount);
    }
}

