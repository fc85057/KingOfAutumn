using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public static event Action<Card> CardPlayed;

    public int position;
    public CardStats cardStats;

    [SerializeField]
    Text cardName;
    [SerializeField]
    Text description;
    [SerializeField]
    Text energyCost;
    [SerializeField]
    Image icon;
    [SerializeField]
    Image image;

    private void Start()
    {
        cardName.text = cardStats.cardName;
        description.text = cardStats.description;
        energyCost.text = cardStats.energyCost.ToString();
        icon.sprite = cardStats.icon;
        image.sprite = cardStats.image;
    }

    public void PlayCard()
    {
        CardPlayed(this);
    }

}
