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
		Debug.Log("Goal");
	}

	public void DeleteObject()
	{
		//¾øÀ½
	}
}
