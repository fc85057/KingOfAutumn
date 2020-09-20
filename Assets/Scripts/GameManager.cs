using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleStatus
{ BattleStart, PlayerTurn, EnemyTurn, BattleWin, BattleLose }

public class GameManager : MonoBehaviour
{

    public static GameManager Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        Card.CardPlayed += CardClicked;
    }

    private CardManager cardManager;
    private UIManager uiManager;

    private Player player;
    private Enemy enemy;

    private BattleStatus currentStatus;
    private bool canPlayCard;

    public void StartBattle()
    {
        cardManager.ResetDeck();

        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();

        currentStatus = BattleStatus.PlayerTurn;

    }

    private void PlayerTurn()
    {
        cardManager.DrawCards();

        canPlayCard = true;

        player.ApplyEffects();
        player.ResetEnergy();
    }

    public void EndTurn()
    {
        if (currentStatus == BattleStatus.PlayerTurn)
        {
            cardManager.DiscardHand();
            currentStatus = BattleStatus.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy taking turn");
        // call enemy AI logic
        yield return new WaitForSeconds(2f);
        currentStatus = BattleStatus.PlayerTurn;
        PlayerTurn();
    }

    private void CardClicked(Card card)
    {
        if (currentStatus == BattleStatus.PlayerTurn && canPlayCard)
        {
            StartCoroutine(PlayCard(card));
        }
    }

    IEnumerator PlayCard(Card card)
    {
        CardStats cardStats = card.cardStats;

        if (player.Energy < cardStats.energyCost)
            yield return null;

        foreach (CardAction action in cardStats.cardActions)
        {
            switch (action)
            {
                case CardAction.Attack:
                    {
                        enemy.TakeDamage(cardStats.damageAmount);
                        break;
                    }
                case CardAction.Heal:
                    {
                        player.Heal(cardStats.healAmount);
                        break;
                    }
                case CardAction.Draw:
                    {
                        cardManager.DrawCard(cardStats.drawAmount);
                        break;
                    }
                case CardAction.Shield:
                    {
                        player.AddShield(cardStats.shieldAmount);
                        break;
                    }
                case CardAction.PlayerEffect:
                    {
                        player.AddEffect(cardStats.playerEffect);
                        break;
                    }
                case CardAction.EnemyEffect:
                    {
                        enemy.AddEffect(cardStats.enemyEffect);
                        break;
                    }
                default:
                    break;
            }

        }

        canPlayCard = false;
        player.ReduceEnergy(cardStats.energyCost);
        yield return new WaitForSeconds(2f);

        // need to somehow call animations to play
        // and get the UI Manager to update everything accordingly

        // card manager discards card
        // UI Manager removes card from transform position

        canPlayCard = true;
    }


    private void EndBattle()
    {
        // reward manager?
        // player card rewards
        // destroy objects: player & enemy
    }

}
