using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardComponent : MonoBehaviour
{

    public BoardData boardData;
    private DeckData deckData;

    private List<GameObject> cardsInPlay;
    private List<GameObject> cardsInDeck;

    private float _zShift = 0;


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
        EventManager.CardClicked += CardClicked;

    }

    private void OnDisable()
    {
        EventManager.BoardShowCardsInPlay -= ShowCardsInPlay;
        EventManager.DeckChanged -= DeckChanged;
        EventManager.BoardChanged -= BoardChanged;
        EventManager.CardClicked -= CardClicked;


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
        //DestroyCardsInPlay();
        CardData cardData = boardData.GetLastPlayedCard();
        Vector3 _position = new Vector3(0, 0, _zShift);
        _zShift -= 0.1f;
        // random slight rotation for each card
        float rotationVariation = 15f;
        float randomVariation;
        CardComponent cardComponenet;

        randomVariation = Random.Range(-rotationVariation, rotationVariation);
        //_position.x = _positionX + randomVariation;
        GameObject cardGameObject = Instantiate(deckData.GetCardPrefab(), _position, Quaternion.identity);
        cardComponenet = cardGameObject.GetComponent<CardComponent>();

        cardComponenet.cardData = cardData;
        cardGameObject.GetComponent<SpriteRenderer>().sprite = cardData.sprite;
        cardGameObject.transform.Rotate(0, 0, randomVariation);
        cardGameObject.name = cardData.ToString();
        cardGameObject.transform.SetParent(gameObject.transform);
        cardsInPlay.Add(cardGameObject);


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
        CardComponent cardComponenet;

        for (int i = 0; i < deckData.GetCards().Count; i++)
        {
            randomVariation = Random.Range(-rotationVariation, rotationVariation);
            GameObject cardGameObject = Instantiate(deckData.GetCardPrefab(), _position, Quaternion.identity);
            cardComponenet = cardGameObject.GetComponent<CardComponent>();
            cardComponenet.cardData = deckData.GetCards()[i];
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

    public void CardClicked(CardComponent card)
    {
        boardData.AddCard(card.cardData);
    }

}
