using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	private GameObject _bullet = null;

	private void Start()
	{
		_bullet = AddressablesManager.Instance.GetResource<GameObject>("Bullet");
		GameObject bullet = Instantiate(_bullet, transform.position, transform.rotation, null);

	}
}
