using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour, IObj
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

	/// <summary>
	/// ���� �����̵�
	/// </summary>
	public void MoveObject(IObj obj)
	{
		Vector2 movePosition = transform.position;
		movePosition += (Vector2)transform.right * 0.5f;

		obj.gameObject.transform.position = movePosition;
		obj.gameObject.transform.rotation = transform.rotation;

	}

	/// <summary>
	/// �����̵� �ߵ�
	/// </summary>
	/// <param name="obj"></param>
	/// <exception cref="System.NotImplementedException"></exception>
	public void CollisionInvoke(IObj obj)
	{
		MatchPotal.MoveObject(obj);
	}
}
