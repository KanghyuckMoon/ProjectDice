using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
	public Potal MatchPotal
	{
		get
		{
			return _matchPotal;
		}
	}


	[SerializeField]
	private Potal _matchPotal = null;

	/// <summary>
	/// ���� �����̵�
	/// </summary>
	public void MoveObject(IObj obj)
	{
		obj.gameObject.transform.rotation = transform.rotation;

	}

}
