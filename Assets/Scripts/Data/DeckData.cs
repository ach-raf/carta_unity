using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckData
{
	private List<CardData> cards;
	private Sprite cardBack;

	public DeckData()
	{
		cards = new List<CardData>();
	}


	public DeckData(List<CardData> _cards)
	{
		cards = _cards;
	}

	public void SetDeck(List<CardData> _cards)
	{
		cards = _cards;
		EventManager.OnDeckChanged(this);
	}

	public List<CardData> GetDeck()
	{
		return cards;
	}

	public void SetCardBack(Sprite _cardBack)
	{
		cardBack = _cardBack;
		EventManager.OnDeckChanged(this);
	}

	public Sprite GetCardBack()
	{
		return cardBack;
	}

	public void AddCard(CardData _card)
	{
		cards.Add(_card);
		EventManager.OnDeckChanged(this);
	}

	public void AddCards(List<CardData> _cards)
	{
		foreach (CardData _card in _cards)
		{
			AddCard(_card);
		}
		EventManager.OnDeckChanged(this);
	}

	public void RemoveCard(CardData _card)
	{
		cards.Remove(_card);
		EventManager.OnDeckChanged(this);
	}

	public CardData GetCardByIndex(int index)
	{
		if (index < cards.Count)
		{
			CardData _card = cards[index];
			RemoveCard(_card);
			return _card;
		}
		else
		{
			return null;
		}
	}

	public CardData GetCard()
	{
		return GetCardByIndex(0);
	}

	public List<CardData> GetCards(int numberOfCards)
	{
		List<CardData> _cards = new List<CardData>();
		while (numberOfCards < cards.Count)
		{
			AddCard(GetCard());
		}
		return _cards;
	}

	public List<CardData> GetCardsByNumber(int _number)
	{
		List<CardData> _cards = new List<CardData>();
		for (int i = 0; i < cards.Count; i++)
		{
			if (cards[i].number == _number)
			{
				AddCard(cards[i]);
			}
		}
		return _cards;
	}

	public int GetCardsCount()
	{
		return cards.Count;
	}

	public void ShuffleCards()
	{
		for (int i = 0; i < cards.Count; i++)
		{
			CardData temp = cards[i];
			int randomIndex = Random.Range(i, cards.Count);
			cards[i] = cards[randomIndex];
			cards[randomIndex] = temp;
		}
	}

	public List<string> GetSuits()
	{
		// return new List<string>() { "flos", "syouf", "jbaben", "zrawet" };
		return new List<string>() { "gold", "sword", "cup", "club" };
	}

	public bool SetupDeck(Sprite[] cardSprites)
	{
		if (cardSprites == null)
		{
			Debug.LogError("Card Sprites are not set");
			return false;
		}

		List<string> _suits = GetSuits();
		int suitIndex;
		int spriteIndex;

		foreach (string _suit in _suits)
		{
			for (int num = 1; num <= 12; num++)
			{
				if (num == 8 || num == 9)
				{
					continue;
				}
				suitIndex = _suits.IndexOf(_suit);
				spriteIndex = (num - 1) + (12 * suitIndex);
				switch (num)
				{
					case 1:
						AddCard(new SpecialCardData(num, _suit, cardSprites[spriteIndex], cardBack));
						break;
					case 2:
						AddCard(new SpecialCardData(num, _suit, cardSprites[spriteIndex], cardBack));
						break;
					case 7:
						AddCard(new SpecialCardData(num, _suit, cardSprites[spriteIndex], cardBack));
						break;
					default:
						AddCard(new CardData(num, _suit, cardSprites[spriteIndex], cardBack));
						break;
				}
			}
		}
		//ShuffleCards();
		return true;
	}


	public int GetIndexOfKey(Dictionary<string, List<int>> dict, string key)
	{
		int index = -1;
		foreach (string value in dict.Keys)
		{
			index++;
			if (key == value)
				return index;
		}
		return -1;
	}



}
