using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IObj
{
	[SerializeField]
	private float _speed = 1f;

	private void Update()
	{
		Move();
	}

	/// <summary>
	/// 총알 이동 함수
	/// </summary>
	private void Move()
	{
		transform.Translate(Vector2.right * _speed * Time.deltaTime);
	}
}
