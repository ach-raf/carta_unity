using System;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public static class EventManager
{

	public static event Action SetupDeck;
	public static void OnSetupDeck() => SetupDeck?.Invoke();

	public static event Action<DeckData> DeckChanged;
	public static void OnDeckChanged(DeckData deckData) => DeckChanged?.Invoke(deckData);

	public static event Action<PlayerData> PlayerChanged;
	public static void OnPlayerChanged(PlayerData playerData) => PlayerChanged?.Invoke(playerData);

	public static event Action<BoardData> BoardChanged;
	public static void OnBoardChanged(BoardData boardkData) => BoardChanged?.Invoke(boardkData);


	public static event Action BoardShowCardsInPlay;
	public static void OnBoardShowCardsInPlay() => BoardShowCardsInPlay?.Invoke();

	//clicked Card
	public static event Action<CardComponent> CardClicked;
	public static void OnCardClicked(CardComponent card_component) => CardClicked?.Invoke(card_component);

	public static event Action<Sprite> CardSpriteChanged;
	public static void OnCardSpriteChanged(Sprite sprite) => CardSpriteChanged?.Invoke(sprite);





}
