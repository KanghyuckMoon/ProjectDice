using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputManager : MonoBehaviour
{
	[SerializeField]
	private List<Dice> _dices = new List<Dice>();
	private float _delay = 0.35f;

	private void Update()
	{
		if(PlayManager.Instance.IsStart)
		{
			return;
		}

		if(_delay > 0)
		{
			_delay -= Time.deltaTime;
			return;
		}

		if(Input.GetKey(KeyCode.W))
		{
			Move(0, 1);
		}
		if (Input.GetKey(KeyCode.S))
		{
			Move(0, -1);
		}
		if (Input.GetKey(KeyCode.D))
		{
			Move(1, 0);
		}
		if (Input.GetKey(KeyCode.A))
		{
			Move(-1, 0);
		}
	}

	private void Move(int x, int y)
	{
		foreach(var dice in _dices)
		{
			if(dice.CanMove(x, y))
			{
				Vector2 movePos = (Vector2)dice.transform.position + new Vector2(x, y);
				dice.DOKill();
				dice.transform.DOMove(movePos, 0.3f);
			}
		}
		_delay = 0.35f;
	}
}
