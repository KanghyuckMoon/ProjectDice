using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeImage : MonoBehaviour, IObserver
{
	[SerializeField]
	private Image _fadeImage;

	private void Start()
	{
		StageManager.Instance.AddObserver(this);
		FadeOut();
	}

	public void FadeIn()
	{
		_fadeImage.rectTransform.DOAnchorPos(new Vector2(0, 0), 0.5f).SetDelay(1).SetEase(Ease.OutQuad);
	}

	public void FadeOut()
	{
		_fadeImage.rectTransform.DOAnchorPos(new Vector2(0, Screen.height), 0.5f).SetDelay(1).SetEase(Ease.OutQuad);
	}

	public void Notice()
	{
		FadeIn();
	}
}
