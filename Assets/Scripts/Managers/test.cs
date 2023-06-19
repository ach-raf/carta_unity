using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class test : MonoBehaviour
{
	public GameObject card;

	private float screenWidth;
	float height;
	float width;


	PlayerControls playerControls;

	private DeckData deckData;
	private BoardData boardData;

	private PlayerData playerData;
	private void Awake()
	{
		playerControls = new PlayerControls();
	}
	private void OnEnable()
	{
		playerControls.Enable();
		EventManager.DeckChanged += DeckChanged;
		EventManager.BoardChanged += BoardChanged;
		EventManager.PlayerChanged += PlayerChanged;


	}

	private void OnDisable()
	{
		playerControls.Disable();
		EventManager.DeckChanged -= DeckChanged;
		EventManager.BoardChanged -= BoardChanged;
		EventManager.PlayerChanged += PlayerChanged;

	}
	void Start()
	{
		height = 2f * Camera.main.orthographicSize;
		width = height * Camera.main.aspect;
		screenWidth = width;
		//InstantiateCards(15);
		EventManager.OnSetupDeck();
		boardData.AddCard(deckData.GetCard());

		//PlayerComponent playerComponent = gameObject.GetComponentInChildren<PlayerComponent>();
		//playerComponent.playerData.AddCard(deckData.GetCard());
		playerData.AddCard(deckData.GetCard());
		playerData.AddCard(deckData.GetCard());
		playerData.AddCard(deckData.GetCard());
		playerData.AddCard(deckData.GetCard());
		playerData.AddCard(deckData.GetCard());

		//EventManager.OnBoardShowCardsInPlay();

	}

	// Update is called once per frame
	void Update()
	{


	}

	void InstantiateCards(int numberOfCards)
	{


		EventManager.OnSetupDeck();

		// function that instantiate cards in a row with a certain distance between them
		// the distance between the cards is the width of the screen divided by the number of cards
		// the position of the first card is the width of the screen divided by 2
		float yPosition = -5f;
		float firstCardPosition = -4.8f;
		float distanceBetweenCards = screenWidth / numberOfCards;
		Debug.Log("screenWidth: " + screenWidth);
		Debug.Log("distanceBetweenCards: " + distanceBetweenCards);
		Debug.Log("firstCardPosition: " + firstCardPosition);
		GameObject _card;
		for (int i = 0; i < numberOfCards; i++)
		{
			_card = Instantiate(card, new Vector3(firstCardPosition + (distanceBetweenCards * i), yPosition, 0), Quaternion.identity);

			_card.GetComponent<CardComponent>().cardData = deckData.GetCard();
			_card.GetComponent<SpriteRenderer>().sprite = _card.GetComponent<CardComponent>().cardData.sprite;
		}
		float previousCardPosition = firstCardPosition;
		/*foreach (CardData cardData in deckData.GetCardsByNumber(2))
		{
			_card = Instantiate(card, new Vector3(previousCardPosition + (distanceBetweenCards * 1), yPosition, 0), Quaternion.identity);
			previousCardPosition = previousCardPosition + (distanceBetweenCards * 1);
			_card.GetComponent<Card>().data = cardData;
			_card.GetComponent<SpriteRenderer>().sprite = cardData.sprite;
		}*/




	}



	private void DeckChanged(DeckData _deckData)
	{
		deckData = _deckData;
	}

	private void BoardChanged(BoardData _boardData)
	{
		boardData = _boardData;

	}

	private void PlayerChanged(PlayerData _playerData)
	{
		playerData = _playerData;
	}
}
