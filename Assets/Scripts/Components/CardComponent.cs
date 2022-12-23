using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour, IClickable
{

	public CardData cardData;
	private SpriteRenderer spriteRenderer;


	// Start is called before the first frame update
	void Start()
	{
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

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

	public void SetSprite(Sprite sprite)
	{
		spriteRenderer.sprite = sprite;
	}


}
