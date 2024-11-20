using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{
    [Header("Card Data")]
    public CardData cardData;
    public int currentHealth;
    public int armor;
    public int stamina;

    [Header("Status Effects")]
    public List<StatusEffect> statusEffect = new List<StatusEffect>();

    [Header("Card UI")]
    public TMP_Text nameText;
    public TMP_Text staminaText;
    public TMP_Text healthText;
    public TMP_Text armorText;
    public Image artwork;
    public Image border;
    public Image namePlate;

    [Header("Testing")]
    public List<StatusEffectData> testEffects;


    private void Start()
    {
        InitializeCard();
    }

    private void Update()
    {
        // Test applying effects with keys
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ApplyTestEffect(0); // Apply the first effect in testEffects
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ApplyTestEffect(1); // Apply the second effect in testEffects
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ApplyTestEffect(2); // Apply the third effect in testEffects
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Heal(2); // Apply the third effect in testEffects
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            AddArmor(2); // Apply the third effect in testEffects
        }


        // Add more keys as needed
    }

    private void InitializeCard()
    {
        currentHealth = cardData.health;
        armor = cardData.armor;
        stamina = cardData.stamina;
        UIUpdate();
        Border();
    }

    #region UI
    void UIUpdate()
    {
        nameText.text = cardData.name;
        healthText.text = currentHealth.ToString();
        armorText.text = armor.ToString();
        staminaText.text = stamina.ToString();
        artwork.sprite = cardData.artwork;
    }

    void Border()
    {
        switch(cardData.rarity)
        {
            case Rarity.Common:
                border.color = Color.cyan;
                break;

            case Rarity.Uncommon:
                border.color = Color.gray;
                break;

            case Rarity.Rare:
                border.color = Color.yellow;
                break;

            case Rarity.Epic:
                border.color = Color.blue;
                break;

            case Rarity.Legendary:
                border.color = Color.red;
                break;

            case Rarity.Godlike:
                border.color = Color.black;
                break;
        }

        namePlate.color = border.color;
    }
    #endregion

    public void TakeDamage(int damage)
    {
        if(armor > 0)
        {
            int damageToArmor = Mathf.Min(armor, damage);
            armor -= damageToArmor;
            damage -= damageToArmor;
        }

        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
            //DCall death here
        }

        UIUpdate();

    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        healthText.text = currentHealth.ToString();

        UIUpdate();

    }

    public void AddArmor(int add)
    {
        armor += add;
        armorText.text = armor.ToString();

        UIUpdate();

    }

    public void ProcessEndOfTurnEffects()
    {
        for (int i = statusEffect.Count - 1; i >= 0; i--)
        {
            statusEffect[i].currentStack--;
            if (statusEffect[i].currentStack <= 0)
            {
                statusEffect.RemoveAt(i); // Remove expired effects
            }
        }
    }

    public void ExecuteAction(ActionData action, Dictionary<ResourceColor, int> availableResources)
    {
        // Check if resources are sufficient
        if (CanExecuteAction(action, availableResources))
        {
            foreach (var effect in action.effects)
            {
                effect.Apply(this); // Apply effect to this card or a target card
            }
        }
        else
        {
            Debug.Log("Not enough resources to execute action: " + action.actionName);
        }
    }

    private bool CanExecuteAction(ActionData action, Dictionary<ResourceColor, int> availableResources)
    {
        foreach (var cost in action.resourceCosts)
        {
            if (!availableResources.ContainsKey(cost.color) || availableResources[cost.color] < cost.amount)
            {
                return false;
            }
        }
        return true;
    }

    #region testing
    private void ApplyTestEffect(int effectIndex)
    {
        if (effectIndex >= 0 && effectIndex < testEffects.Count)
        {
            StatusEffectData effectData = testEffects[effectIndex];
            AddStatusEffect(effectData);
            Debug.Log($"{effectData.effectName} applied to {gameObject.name} with {effectData.initialStacks} stacks.");
        }
    }

    public void AddStatusEffect(StatusEffectData effectData)
    {
        StatusEffect existingEffect = statusEffect.Find(e => e.effectData == effectData);
        if (existingEffect != null)
        {
            existingEffect.currentStack = effectData.initialStacks;
        }
        else
        {
            StatusEffect newEffect = new StatusEffect(effectData);
            statusEffect.Add(newEffect);
        }
    }
    #endregion
}
