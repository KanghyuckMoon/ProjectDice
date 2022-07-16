using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
	/// <summary>
	/// 게임 리셋
	/// </summary>
	public void Invoke()
	{
		PlayManager.Instance.ResetGame();
	}
}
