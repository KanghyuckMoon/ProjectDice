using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputManager : MonoBehaviour
{
	public bool IsRollMode
	{
		get
		{
			return _isRollMode;
		}
	}

	[SerializeField]
	private List<Dice> _dices = new List<Dice>();
	private float _delay = 0.35f;

	private bool _isRollMode = false;

	private List<IObserver> _observers = new List<IObserver>();

	public void AddObserver(IObserver observer)
	{
		_observers.Add(observer);
	}

	private void Update()
	{
		if(PlayManager.Instance.IsStart)
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_isRollMode = !_isRollMode;
			SoundManager.Instance.PlayEFF(AudioEFFType.SwitchSound);
			foreach (var observer in _observers)
			{
				observer.Notice();
			}
		}

		if (_delay > 0)
		{
			_delay -= Time.deltaTime;
			return;
		}

		if(_isRollMode)
		{
			if (Input.GetKey(KeyCode.D))
			{
				Roll(90);
			}
			if (Input.GetKey(KeyCode.A))
			{
				Roll(-90);
			}
		}
		else
		{
			if (Input.GetKey(KeyCode.W))
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

	}


	/// <summary>
	/// 주사위 이동
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
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
		SoundManager.Instance.PlayEFF(AudioEFFType.MoveSound);
		_delay = 0.35f;
	}

	/// <summary>
	/// 주사위 돌리기
	/// </summary>
	/// <param name="angle"></param>
	private void Roll(int angle)
	{
		foreach (var dice in _dices)
		{
			dice.DOKill();
			Vector3 rotateVector = dice.transform.eulerAngles + new Vector3(0,0, angle);
			dice.transform.DORotate(rotateVector, 0.3f);
		}
		SoundManager.Instance.PlayEFF(AudioEFFType.MoveSound);
		_delay = 0.35f;
	}
}
