using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.Rendering.Universal;
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
	[SerializeField]
	private ColorType _colorType = ColorType.None;

	private Queue<IObj> _objs = new Queue<IObj>();
	private Coroutine _coroutine = null;

	private void Start()
	{
		SetColor();
	}

	/// <summary>
	/// 색깔 설정
	/// </summary>
	private void SetColor()
	{
		Color color = Color.black;

		switch (_colorType)
		{
			case ColorType.Cyan:
				color = new Color(0, 1, 0.98f);
				break;
			case ColorType.Blue:
				color = new Color(0, 0.3f, 1);
				break;
			case ColorType.Red:
				color = new Color(1, 0, 0.2f);
				break;
			case ColorType.Green:
				color = new Color(0, 1, 0.6f);
				break;
			case ColorType.Orange:
				color = new Color(1, 0.5f, 0);
				break;
			case ColorType.Yellow:
				color = new Color(1, 1, 0);
				break;
		}

		GetComponent<SpriteRenderer>().color = color;
		GetComponent<Light2D>().color = color;
	}

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
