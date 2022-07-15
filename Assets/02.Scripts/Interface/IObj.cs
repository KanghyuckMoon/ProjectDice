using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObj
{
	GameObject gameObject
	{
		get;
	}

	/// <summary>
	/// 충돌시 효과 발생
	/// </summary>
	void CollisionInvoke(IObj obj);

}
