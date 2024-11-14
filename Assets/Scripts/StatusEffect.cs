using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusEffectType { Buff, Debuff}

[System.Serializable]
public class StatusEffect
{
    public StatusEffectData effectData;
    public int currentStack;

    public StatusEffect(StatusEffectData data)
    {
        effectData = data;
        currentStack = data.initialStacks;
    }

    public bool IsActive() => currentStack > 0 && effectData.isActive;
}
