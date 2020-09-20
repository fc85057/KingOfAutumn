using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private CardStats[] allCardsArray;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cardSlotsContainer;

    private List<Transform> cardSlots;

    private Dictionary<string, CardStats> allCards;

    private List<CardStats> deck;
    private List<CardStats> hand;
    private List<CardStats> drawPile;
    private List<CardStats> discardPile;

    private void Awake()
    {
        foreach (Transform cardSlot in cardSlotsContainer.transform)
        {
            cardSlots.Add(cardSlot);
        }

        allCards = new Dictionary<string, CardStats>();
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        foreach (var card in allCardsArray)
        {
            allCards.Add(card.cardName, card);
        }

        for (int i = 0; i < 2; i++)
        {
            deck.Add(allCards["Pinecone Toss"]);
            deck.Add(allCards["Pumpkin Juice"]);
        }

        for (int i = 0; i < 5; i++)
        {
            deck.Add(allCards["Wind"]);
        }

        deck.Add(allCards["Gust"]);
        deck.Add(allCards["Storm"]);
        deck.Add(allCards["Pumpkin Lager"]);

    }

    public void ResetDeck()
    {
        drawPile.Clear();
        discardPile.Clear();
        hand.Clear();

        foreach (CardStats cardInDeck in deck)
        {
            drawPile.Add(cardInDeck);
        }
    }

    public void DrawCard(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            if (drawPile.Count == 0)
                ShuffleDeck();

            for (int j = 0; j < cardSlots.Count; j++)
            {
                if (cardSlots[j].childCount == 0)
                {
                    CardStats drawnCard = drawPile[Random.Range(0, drawPile.Count)];
                    drawPile.Remove(drawnCard);
                    hand.Add(drawnCard);

                    GameObject newCard = Instantiate(cardPrefab, cardSlots[j], false);
                    newCard.GetComponent<Card>().position = j;
                    newCard.GetComponent<Card>().cardStats = drawnCard;
                }
            }
        }
    }

    public void DrawCards()
    {
        for (int i = 0; i < 5; i++)
        {
            if (drawPile.Count == 0)
                ShuffleDeck();

            CardStats cardStats = drawPile[Random.Range(0, drawPile.Count)];
            drawPile.Remove(cardStats);
            hand.Add(cardStats);

            GameObject newCard = Instantiate(cardPrefab, cardSlots[i], false);
            newCard.GetComponent<Card>().cardStats = cardStats;
            newCard.GetComponent<Card>().position = i;

        }
    }

    private void ShuffleDeck()
    {

        foreach (CardStats card in discardPile)
        {
            drawPile.Add(card);
        }

        discardPile.Clear();

    }

    public void DiscardHand()
    {
        foreach (CardStats card in hand)
        {
            discardPile.Add(card);
        }

        foreach (Transform slot in cardSlots)
        {
            if (slot.childCount > 0)
            {
                Destroy(slot.GetChild(0).gameObject);
            }
        }

        hand.Clear();

    }

    public void DiscardCard(int position)
    {
        if (cardSlots[position].childCount > 0)
        {
            GameObject cardObject = cardSlots[position].GetChild(0).gameObject;

            hand.Remove(cardObject.GetComponent<Card>().cardStats);
            discardPile.Add(cardObject.GetComponent<Card>().cardStats);

            Destroy(cardObject);
        }
    }

}
