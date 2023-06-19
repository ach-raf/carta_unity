using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckComponent : MonoBehaviour
{
    public DeckData deckData;
    public Sprite[] cardSprites;

    public GameObject cardPrefab;

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
        deckData.SetCardPrefab(cardPrefab);
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
    public void CardClicked(CardComponent card)
    {
        deckData.RemoveCard(card.cardData);
    }


}
