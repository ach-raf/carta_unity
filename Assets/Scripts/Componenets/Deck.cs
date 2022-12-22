using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	public DeckData deckData;
	public Sprite[] cardSprites;

	public Sprite cardBack;


	void OnEnable()
	{
		EventManager.SetupDeck += SetupDeck;
		EventManager.CardClicked += CardClicked;

	}

	void OnDisable()
	{
		EventManager.SetupDeck -= SetupDeck;
		EventManager.CardClicked -= CardClicked;
	}

	void Awake()
	{
		deckData = new DeckData();
		deckData.SetCardBack(cardBack);
	}
	void Start()
	{
	}

	void Update()
	{

	}

	public void SetupDeck()
	{
		deckData.SetupDeck(cardSprites);
	}

	//card clicked
	public void CardClicked(Card card)
	{
		deckData.RemoveCard(card.cardData);
	}


}
