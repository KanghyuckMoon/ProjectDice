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
	/// �浹�� ȿ�� �߻�
	/// </summary>
	void CollisionInvoke(IObj obj);

}
