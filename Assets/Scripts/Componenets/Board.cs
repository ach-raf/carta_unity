using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

	public BoardData boardData;
	private DeckData deckData;

	public GameObject cardPrefab;

	private List<GameObject> cardsInPlay;
	private List<GameObject> cardsInDeck;

	private void Awake()
	{
		boardData = new BoardData();
		cardsInPlay = new List<GameObject>();
		cardsInDeck = new List<GameObject>();
	}

	private void OnEnable()
	{

		EventManager.BoardShowCardsInPlay += ShowCardsInPlay;
		EventManager.DeckChanged += DeckChanged;
		EventManager.BoardChanged += BoardChanged;

	}

	private void OnDisable()
	{
		EventManager.BoardShowCardsInPlay -= ShowCardsInPlay;
		EventManager.DeckChanged -= DeckChanged;
		EventManager.BoardChanged -= BoardChanged;

	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void ShowCardsInPlay()
	{
		DestroyCardsInPlay();

		float _positionX = 0f;
		Vector2 _position = new Vector2(0, 0);
		// random slight rotation for each card
		float rotationVariation = 5f;
		float randomVariation;
		Card cardComponenet;
		for (int i = 0; i < boardData.GetCurrentCards().Count; i++)
		{
			randomVariation = Random.Range(-rotationVariation, rotationVariation);
			_position.x = _positionX + randomVariation;
			GameObject cardGameObject = Instantiate(cardPrefab, _position, Quaternion.identity);

			cardComponenet = cardGameObject.GetComponent<Card>();
			cardComponenet.cardData = boardData.GetCurrentCards()[i];
			cardComponenet.cardData.SetSprite(cardComponenet.cardData.sprite);
			cardGameObject.transform.Rotate(0, 0, randomVariation);
			cardGameObject.name = cardComponenet.cardData.ToString();
			cardGameObject.transform.SetParent(gameObject.transform);
			cardsInPlay.Add(cardGameObject);
		}
	}

	void DestroyCardsInPlay()
	{
		for (int i = 0; i < cardsInPlay.Count; i++)
		{
			Destroy(cardsInPlay[i]);
		}
		cardsInPlay.Clear();
	}

	void ShowDeck()
	{
		DestroyDeck();

		// show deck
		float _positionX = 13f;
		Vector2 _position = new Vector2(_positionX, 0);

		float rotationVariation = 5f;
		float randomVariation;
		Card cardComponenet;

		for (int i = 0; i < deckData.GetDeck().Count; i++)
		{
			randomVariation = Random.Range(-rotationVariation, rotationVariation);
			GameObject cardGameObject = Instantiate(cardPrefab, _position, Quaternion.identity);
			cardComponenet = cardGameObject.GetComponent<Card>();
			cardComponenet.cardData = deckData.GetDeck()[i];
			cardComponenet.cardData.SetSprite(cardComponenet.cardData.backSprite);
			cardGameObject.transform.Rotate(0, 0, randomVariation);
			cardGameObject.name = cardComponenet.cardData.ToString();
			cardGameObject.transform.SetParent(gameObject.transform);
			cardsInDeck.Add(cardGameObject);
		}

	}

	void DestroyDeck()
	{
		if (cardsInDeck == null)
		{

		}
		else
		{
			for (int i = 0; i < cardsInDeck.Count; i++)
			{
				Destroy(cardsInDeck[i]);
			}
			cardsInDeck.Clear();
		}

	}

	private void DeckChanged(DeckData _deckData)
	{
		deckData = _deckData;
		ShowDeck();
	}

	private void BoardChanged(BoardData _boardData)
	{
		boardData = _boardData;
		ShowCardsInPlay();
	}

}
