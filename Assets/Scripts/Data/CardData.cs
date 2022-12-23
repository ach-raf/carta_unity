using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardData
{
	public int number;
	public string suit;
	public Sprite sprite;

	public Sprite backSprite;

	private Sprite currentSprite;

	public CardData(int _number, string _suit, Sprite _sprite, Sprite _backSprite)
	{
		number = _number;
		suit = _suit;
		sprite = _sprite;
		backSprite = _backSprite;
		SetSprite(backSprite);
	}

	public Sprite GetSprite()
	{
		return currentSprite;
	}

	public void SetSprite(Sprite _sprite)
	{
		currentSprite = _sprite;

	}


	public bool CanPlay(CardData card)
	{
		if (card.suit == suit)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public virtual void Effect()
	{
		Debug.Log("Card Effect");
	}

	public override string ToString()
	{
		return number + " of " + suit;
	}
}

