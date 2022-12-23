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
	}

	public void AddCardToHand(CardData card)
	{
		cardsInHand.Add(card);
	}

	public void RemoveCardFromHand(CardData card)
	{
		cardsInHand.Remove(card);
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
	}


}

