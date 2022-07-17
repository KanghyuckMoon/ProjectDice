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
		if(_isStageClear)
		{
			return;
		}

		_isStageClear = true;

		obj.DeleteObject();
		StageManager.Instance.NextStage();
	}

	public void DeleteObject()
	{
		//¾øÀ½
	}
}
