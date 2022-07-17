using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIAnimation : MonoBehaviour
{
	[SerializeField]
	private RectTransform _stageText;
	[SerializeField]
	private RectTransform _tipText;
	[SerializeField]
	private RectTransform _modeText;
	[SerializeField]
	private RectTransform _playButton;
	[SerializeField]
	private RectTransform _resetButton;

	private void Start()
	{
		AnimStageText();
		AnimTipText();
		AnimModeText();
		AnimResetButton();
		AnimPlayButton();
	}

	private void AnimStageText()
	{
		Vector2 origin = _stageText.anchoredPosition;
		_stageText.anchoredPosition = origin + new Vector2(0, 500);
		_stageText.DOAnchorPos(origin, 1).SetEase(Ease.OutQuad).SetDelay(1.5f);
	}

	private void AnimTipText()
	{
		Vector2 origin = _tipText.anchoredPosition;
		_tipText.anchoredPosition = origin + new Vector2(-500, 0);
		_tipText.DOAnchorPos(origin, 1).SetEase(Ease.OutQuad).SetDelay(1.5f);
	}

	private void AnimModeText()
	{
		Vector2 origin = _modeText.anchoredPosition;
		_modeText.anchoredPosition = origin + new Vector2(500, 0);
		_modeText.DOAnchorPos(origin, 1).SetEase(Ease.OutQuad).SetDelay(1.5f);
	}

	private void AnimResetButton()
	{
		Vector2 origin = _resetButton.anchoredPosition;
		_resetButton.anchoredPosition = origin + new Vector2(-500, 0);
		_resetButton.DOAnchorPos(origin, 1).SetEase(Ease.OutQuad).SetDelay(1.5f);
	}

	private void AnimPlayButton()
	{
		Vector2 origin = _playButton.anchoredPosition;
		_playButton.anchoredPosition = origin + new Vector2(500, 0);
		_playButton.DOAnchorPos(origin, 1).SetEase(Ease.OutQuad).SetDelay(1.5f);
	}
}
