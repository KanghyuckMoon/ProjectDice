using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class ClearText : MonoBehaviour, IObserver
{
	[SerializeField]
	private TextMeshProUGUI _clearText = null;

	public void Notice()
	{
		_clearText.gameObject.SetActive(true);
		_clearText.transform.localScale = Vector3.zero;
		_clearText.color = Color.yellow;
		_clearText.DOColor(Color.white, 0.3f);
		_clearText.transform.DOScale(1, 0.3f).SetEase(Ease.OutElastic);
	}

	private void Start()
	{
		StageManager.Instance.AddObserver(this);
	}


}
