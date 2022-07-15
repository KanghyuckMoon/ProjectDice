using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
	public Potal MatchPotal
	{
		get
		{
			return _matchPotal;
		}
	}
	public Dice Dice
	{
		get
		{
			_dice = GetComponentInParent<Dice>();
			return _dice;
		}
	}

	[SerializeField]
	private Potal _matchPotal = null;
	[SerializeField]
	private Dice _dice = null;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Obj"))
		{
			MatchPotal.MoveObject(collision.GetComponent<IObj>());
		}
	}

	/// <summary>
	/// 물건 순간이동
	/// </summary>
	public void MoveObject(IObj obj)
	{
		Vector2 movePosition = transform.position;
		movePosition += (Vector2)transform.right * 1;

		obj.gameObject.transform.position = movePosition;
		obj.gameObject.transform.rotation = transform.rotation;

	}

}
