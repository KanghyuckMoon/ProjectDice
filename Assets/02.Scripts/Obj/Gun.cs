using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IObserver
{
	private GameObject _bullet = null;
	private bool _isShot = false;

	public void Notice()
	{
		GameObject bullet = Instantiate(_bullet, transform.position, transform.rotation, null);
	}

	private void Start()
	{
		_bullet = AddressablesManager.Instance.GetResource<GameObject>("Bullet");
		PlayManager.Instance.AddObserver(this);
	}
}
