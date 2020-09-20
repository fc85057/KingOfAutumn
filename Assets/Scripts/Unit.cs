using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static event Action<Unit> DamageTaken;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [SerializeField] private int maxShield = 50;
    [SerializeField] private int currentShield;

    [SerializeField] private int strength;

    [SerializeField] private int healing;

    [SerializeField] List<Effect> effects;

    private void Start()
    {
        currentHealth = maxHealth;
        currentShield = 0;
        strength = 0;
        healing = 0;
        effects = new List<Effect>();
    }

    public void TakeDamage(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            if (currentShield > 0)
            {
                currentShield--;
            }
            else
            {
                currentHealth--;
            }
        }
        DamageTaken(this);
    }

    public void Heal(int healthBoost)
    {
        for (int i = 0; i < healthBoost; i++)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth++;
            }
        }
    }

    public void AddShield(int shieldAmount)
    {
        for (int i = 0; i < shieldAmount; i++)
        {
            if (currentShield < maxShield)
            {
                currentShield++;
            }
        }
    }

    public void ApplyEffects()
    {
        foreach (Effect effect in effects)
        {
            // apply effect
        }
    }

    public void AddEffect(Effect effect)
    {
        effects.Add(effect);
    }

    public void RemoveEffect(Effect effect)
    {
        effects.Remove(effect);
    }

    public void IncreaseStrength(int strengthToAdd)
    {
        strength += strengthToAdd;
    }

    public void DecreaseStrength(int strengthToDecrease)
    {
        strength -= strengthToDecrease;
    }

}
