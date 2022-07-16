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

	public string Address
	{
		get
		{
			return "Potal";
		}
	}

	[SerializeField]
	private Potal _matchPotal = null;
	[SerializeField]
	private Dice _dice = null;

	private Queue<IObj> _objs = new Queue<IObj>();
	private Coroutine _coroutine = null;

	/// <summary>
	/// 물건 순간이동
	/// </summary>
	public void MoveObject(IObj obj)
	{
		obj.DeleteObject();
		_objs.Enqueue(obj);
		if (_coroutine == null)
		{
			_coroutine = StartCoroutine(CopyObject());
		}
	}

	private IEnumerator CopyObject()
	{
		IObj obj = _objs.Dequeue();
		for (int i = 0; i < Dice.DiceScale; ++i)
		{
			GameObject instanceObj = PoolManager.Instance.GetObject(obj.Address);
			if(instanceObj == null)
			{
				instanceObj = Instantiate(obj.gameObject, transform.position, transform.rotation, null);
			}

			Vector2 movePosition = transform.position;
			movePosition += (Vector2)transform.right * 0.5f;

			instanceObj.transform.rotation = transform.rotation;
			instanceObj.transform.position = movePosition;
			instanceObj.transform.rotation = transform.rotation;
			instanceObj.SetActive(true);

			yield return new WaitForSeconds(0.2f);
		}
		if(_objs.Count > 0)
		{
			StartCoroutine(CopyObject());
		}
		else
		{
			_coroutine = null;
		}
	}

	/// <summary>
	/// 순간이동 발동
	/// </summary>
	/// <param name="obj"></param>
	/// <exception cref="System.NotImplementedException"></exception>
	public void CollisionInvoke(IObj obj)
	{
		MatchPotal.MoveObject(obj);
	}


	/// <summary>
	/// 포탈 삭제
	/// </summary>
	/// <param name="obj"></param>
	public void DeleteObject()
	{
		PoolManager.Instance.RegisterObject(Address, gameObject);
		gameObject.SetActive(false);
	}
}
