using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionEffect : ScriptableObject
{
    public abstract void Apply(Card target);

    public virtual void ApplyToBoard()
    {
        // Override in specific effects that don’t need a target, e.g., board-wide buffs
    }
}

//[CreateAssetMenu(fileName = "Damage Effect", menuName = "Card Game/Effects/Damage")]
//public class DamageEffect : ActionEffect
//{
//    public int damageAmount;

//    public override void Apply(Card target)
//    {
//        target.TakeDamage(damageAmount);
//    }
//}

//[CreateAssetMenu(fileName = "Heal Effect", menuName = "Card Game/Effects/Heal")]
//public class HealEffect : ActionEffect
//{
//    public int healAmount;

//    public override void Apply(Card target)
//    {
//        target.Heal(healAmount);
//    }
//}

//[CreateAssetMenu(menuName = "Card Game/Effects/Armor")]
//public class ArmorEffect : ActionEffect
//{
//    public int armorAmount;

//    public override void Apply(Card target)
//    {
//        target.AddArmor(armorAmount);
//    }
//}

