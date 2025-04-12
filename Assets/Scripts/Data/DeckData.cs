using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckData
{
    private List<CardData> cards;
    private Sprite cardBack;
    private GameObject cardPrefab;


    public DeckData()
    {
        cards = new List<CardData>();
        EventManager.OnDeckChanged(this);
    }

    public void SetDeck(List<CardData> _cards)
    {
        cards = _cards;
        EventManager.OnDeckChanged(this);
    }

    public List<CardData> GetCards()
    {
        return cards;
    }

    public void SetCardBackSprite(Sprite _cardBackSprite)
    {
        cardBack = _cardBackSprite;
        EventManager.OnDeckChanged(this);
    }

    public Sprite GetCardBackSprite()
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
    }

    public void RemoveCard(CardData _card)
    {
        cards.Remove(_card);
        EventManager.OnDeckChanged(this);
    }

    public CardData GetCardByIndex(int index)
    {
        if (index <= cards.Count)
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

    public CardData GetFirstCard()
    {
        return GetCardByIndex(0);
    }



    public int GetCardsCount()
    {
        return cards.Count;
    }

    public void ShuffleCards()
    {
        CardData temp;
        for (int i = 0; i < cards.Count; i++)
        {
            temp = cards[i];
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
                // how the sprite index is calculated, is due to the sprite sheet, there is 4 rows of 12 cards, each row is a suit
                // with their index going from 0 to 11 for the first suit, 12 to 23 for the second suit, and so on
                spriteIndex = (num - 1) + (12 * suitIndex);
                switch (num)
                {
                    case 1:
                    case 2:
                    case 7:
                        AddCard(new SpecialCardData(num, _suit, cardSprites[spriteIndex], cardBack));
                        break;
                    default:
                        AddCard(new CardData(num, _suit, cardSprites[spriteIndex], cardBack));
                        break;
                }
            }
        }
        ShuffleCards();
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

    public void SetCardPrefab(GameObject _cardPrefab)
    {
        cardPrefab = _cardPrefab;
        EventManager.OnDeckChanged(this);
    }

    public GameObject GetCardPrefab()
    {
        return cardPrefab;
    }






}
