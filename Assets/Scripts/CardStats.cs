using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardAction { Attack, Heal, Shield, Draw, PlayerEffect, EnemyEffect }

[CreateAssetMenu(fileName ="NewCard", menuName = "New Card")]
public class CardStats : ScriptableObject
{

    public string cardName;
    public string description;
    public int energyCost;
    public Sprite icon;
    public Sprite image;

    public int damageAmount;
    public int healAmount;
    public int shieldAmount;
    public int drawAmount;
    public Effect playerEffect;
    public Effect enemyEffect;

    public CardAction[] cardActions;

}
