using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveModeText : MonoBehaviour, IObserver
{
	[SerializeField]
	private TextMeshProUGUI _modeText = null;
	private InputManager _inputManager = null;

	public void Notice()
	{
		if(_inputManager.IsRollMode)
		{
			_modeText.text = "RotateMode";
			_modeText.color = Color.yellow;
		}
		else
		{
			_modeText.text = "MoveMode";
			_modeText.color = Color.white;
		}
	}

	private void Start()
	{
		_inputManager = GameObject.FindObjectOfType<InputManager>();
		_inputManager.AddObserver(this);
		Notice();
	}
}
