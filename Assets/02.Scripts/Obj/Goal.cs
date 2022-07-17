using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour, IObj
{
	public string Address
	{
		get
		{
			return "Goal";
		}
	}

	private bool _isStageClear = false;

	public void CollisionInvoke(IObj obj)
	{
		obj.DeleteObject();

		if (_isStageClear)
		{
			return;
		}

		_isStageClear = true;

		StageManager.Instance.NextStage();
		SoundManager.Instance.PlayEFF(AudioEFFType.ClearSound);
	}

	public void DeleteObject()
	{
		//¾øÀ½
	}
}
