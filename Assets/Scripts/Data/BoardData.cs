using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardData
{
	private List<CardData> currentCards;
	private CardData lastPlayedCard;

	public BoardData()
	{
		currentCards = new List<CardData>();
		lastPlayedCard = null;
		EventManager.OnBoardChanged(this);
	}

	public List<CardData> GetCurrentCards()
	{
		return currentCards;
	}

	public void AddCard(CardData card)
	{
		currentCards.Add(card);
		lastPlayedCard = card;
		EventManager.OnBoardChanged(this);
	}

	public CardData GetLastPlayedCard()
	{
		return lastPlayedCard;
	}

	public void RemoveCard(CardData card)
	{
		currentCards.Remove(card);
		EventManager.OnBoardChanged(this);
	}

	public CardData ClearBoard()
	{
		currentCards.Clear();
		EventManager.OnBoardChanged(this);
		return lastPlayedCard;
	}


	public override string ToString()
	{
		return $"9a3a: {currentCards}\nlast played card: {lastPlayedCard}";
	}


}
