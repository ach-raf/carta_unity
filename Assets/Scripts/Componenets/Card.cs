using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour, IClickable
{

	public CardData cardData;

	private void OnEnable()
	{
		EventManager.CardSpriteChanged += CardSpriteChanged;
	}

	private void OnDisable()
	{
		EventManager.CardSpriteChanged -= CardSpriteChanged;
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void click()
	{
		// log data clicked
		Debug.Log(cardData.ToString());
		cardData.Effect();
		EventManager.OnCardClicked(this);

	}

	public void CardSpriteChanged(Sprite _sprite)
	{
		GetComponent<SpriteRenderer>().sprite = _sprite;
	}
}
