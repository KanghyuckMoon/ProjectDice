using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountWall : MonoBehaviour, IObj
{
	public string Address
	{
		get
		{
			return "CountWall";
		}
	}

	[SerializeField]
	private int _count;
	private TextMeshPro _textMesh;

	private void Start()
	{
		_textMesh = GetComponentInChildren<TextMeshPro>();
		TextUpdate();
	}

	private void TextUpdate()
	{
		_textMesh.text = $"{_count}";
	}

	public void CollisionInvoke(IObj obj)
	{
		_count--;
		obj.DeleteObject();
		TextUpdate();
		if(_count == 0)
		{
			DeleteObject();
		}
	}

	public void DeleteObject()
	{
		gameObject.SetActive(false);
	}
}
