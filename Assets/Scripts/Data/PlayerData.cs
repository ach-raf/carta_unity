using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
	private List<CardData> cardsInHand;
	private CardData lastPlayedCard;

	public PlayerData()
	{
		cardsInHand = new List<CardData>();
		EventManager.OnPlayerChanged(this);

	}

	public void AddCard(CardData card)
	{
		cardsInHand.Add(card);
		EventManager.OnPlayerChanged(this);
	}

	public void RemoveCard(CardData card)
	{
		cardsInHand.Remove(card);
		EventManager.OnPlayerChanged(this);
	}

	public void SetLastPlayedCard(CardData card)
	{
		lastPlayedCard = card;
	}

	public CardData GetLastPlayedCard()
	{
		return lastPlayedCard;
	}

	public List<CardData> GetCardsInHand()
	{
		return cardsInHand;
	}

	public void ClearCardsInHand()
	{
		cardsInHand.Clear();
		EventManager.OnPlayerChanged(this);
	}


}

