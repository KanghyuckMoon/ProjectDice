using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IObj
{
	public string Address
	{
		get
		{
			return "Wall";
		}
	}

	public void CollisionInvoke(IObj obj)
	{
		obj.DeleteObject();
	}

	public void DeleteObject()
	{
		//¾øÀ½
	}
}
