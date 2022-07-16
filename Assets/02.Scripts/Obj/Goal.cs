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

	public void CollisionInvoke(IObj obj)
	{
		StageManager.Instance.NextStage();
	}

	public void DeleteObject()
	{
		//¾øÀ½
	}
}
