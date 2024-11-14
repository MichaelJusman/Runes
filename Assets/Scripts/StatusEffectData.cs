using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status Effect", menuName = "Card Game/Status Effect")]
public class StatusEffectData : ScriptableObject
{
    public string effectName;
    public string effectDescription;
    public StatusEffectType type;   // Buff or Debuff
    public int initialStacks;       // Starting duration or stacks
    public bool isRemovable;        // If this effect can be removed by a cleanse
    public bool isActive;           // For effects like "Stun" that prevent actions
}
