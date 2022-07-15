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

	[SerializeField]
	private int _scale = 1;
}
