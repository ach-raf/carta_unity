using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpecialCardData : CardData
{
	public SpecialCardData(int _number, string _suit, Sprite _sprite, Sprite _backSprite) : base(_number, _suit, _sprite, _backSprite)
	{
	}

	public override void Effect()
	{
		Debug.Log("Special Card Effect");
	}
}

