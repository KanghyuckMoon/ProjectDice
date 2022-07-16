using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
	public int DiceScale
	{
		get
		{
			return _scale;
		}
	}

	public Vector2 Pos
	{
		get
		{
			return _pos;
		}
		set
		{
			_pos = value;
		}
	}

	[SerializeField]
	private int _scale = 1;
	[SerializeField]
	private List<Sprite> _sprites;

	private Vector2 _pos = Vector2.zero;

	private void Start()
	{
		SetScaleSprite();
	}

	/// <summary>
	/// 눈금 수 이미지 설정
	/// </summary>
	private void SetScaleSprite()
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = _sprites[_scale];
	}

	/// <summary>
	/// 주사위가 움직일 수 있는지
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public bool CanMove(int x, int y)
	{
		Vector2 movePos = (Vector2)transform.position + new Vector2(x * 0.45f, y * 0.45f);
		int layerMask = 1 << LayerMask.NameToLayer("Wall");
		RaycastHit2D raycastHit2D = Physics2D.Raycast(movePos, new Vector3(x, y, 0), 0.5f, layerMask);
		if (raycastHit2D)
		{
			raycastHit2D.collider.gameObject.TryGetComponent<Dice>(out Dice dice);
			if (dice != null)
			{
				if(dice.CanMove(x, y))
				{

					return true;
				}
			}
			return false;
		}
		else
		{
			return true;
		}
	}

	private void OnDrawGizmos()
	{
		Vector2 movePos = (Vector2)transform.position + new Vector2(0, 0.45f);
		Debug.DrawRay(movePos, new Vector3(0, 0.5f, 0), Color.red);
	}

}
