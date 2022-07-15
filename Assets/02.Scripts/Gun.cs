using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField]
	private GameObject _bullet = null;

	private void Start()
	{
		GameObject bullet = Instantiate(_bullet, transform.position, transform.rotation, null);

	}
}
