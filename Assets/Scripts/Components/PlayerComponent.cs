using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
	public PlayerData playerData;
	private List<GameObject> cardsInHand;

	private DeckData deckData;

	private void OnEnable()
	{

		EventManager.DeckChanged += DeckChanged;

	}

	private void OnDisable()
	{
		EventManager.DeckChanged -= DeckChanged;


	}

	// Start is called before the first frame update
	void Start()
	{
		playerData = new PlayerData();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void ShowCardsInHand()
	{
		DestroyCardsInHand();


		// function that instantiate cards in a row with a certain distance between them
		// the distance between the cards is the width of the screen divided by the number of cards
		// the position of the first card is the width of the screen divided by 2
		float height = 2f * Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
		float screenWidth = width;
		float yPosition = -5f;
		float firstCardPosition = -15f;
		int numberOfCards = playerData.GetCardsInHand().Count;
		float distanceBetweenCards = screenWidth / numberOfCards;


		Vector2 _position = new Vector2(0, yPosition);
		// random slight rotation for each card
		float rotationVariation = 5f;
		float randomVariation;
		CardComponent cardComponenet;

		int i = 0;
		foreach (CardData cardData in playerData.GetCardsInHand())
		{
			randomVariation = Random.Range(-rotationVariation, rotationVariation);
			_position.x = firstCardPosition + (distanceBetweenCards * i);
			GameObject cardGameObject = Instantiate(deckData.GetCardPrefab(), _position, Quaternion.identity);
			cardComponenet = cardGameObject.GetComponent<CardComponent>();
			cardComponenet.cardData = cardData;
			cardGameObject.GetComponent<SpriteRenderer>().sprite = cardData.sprite;
			cardGameObject.transform.Rotate(0, 0, randomVariation);
			cardGameObject.name = cardData.ToString();
			cardGameObject.transform.SetParent(gameObject.transform);
			cardsInHand.Add(cardGameObject);
			i++;
		}


	}

	void DestroyCardsInHand()
	{
		for (int i = 0; i < cardsInHand.Count; i++)
		{
			Destroy(cardsInHand[i]);
		}
		cardsInHand.Clear();
	}

	private void DeckChanged(DeckData _deckData)
	{
		deckData = _deckData;
	}
}
