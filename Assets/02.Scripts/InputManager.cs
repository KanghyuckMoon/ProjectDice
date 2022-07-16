using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	[SerializeField]
	private List<Dice> _dices = new List<Dice>();

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			Move(0, 1);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Move(0, -1);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			Move(1, 0);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			Move(-1, 0);
		}
	}

	private void Move(int x, int y)
	{
		foreach(var dice in _dices)
		{
			int laytMask = 1 << LayerMask.NameToLayer("Wall");
			if(!Physics2D.Raycast(dice.transform.position, new Vector3(x, y, 0),0.5f, laytMask))
			{

			}
		}
	}
}
