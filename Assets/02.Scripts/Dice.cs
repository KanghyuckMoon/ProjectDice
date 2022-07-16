using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
	public int DiceScale
	{
		get
		{
			return _scale;
		}
	}

	public Vector2 Pos
	{
		get
		{
			return _pos;
		}
		set
		{
			_pos = value;
		}
	}

	[SerializeField]
	private int _scale = 1;
	private Vector2 _pos = Vector2.zero;
}
