using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
	/// <summary>
	/// ���� ����
	/// </summary>
	public void Invoke()
	{
		PlayManager.Instance.OnPlay();
		gameObject.SetActive(false);
	}


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			Invoke();
		}
	}
}
