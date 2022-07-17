using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipText : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _tipText = null;
	[SerializeField]
	private TipTextSO _tipTextSO = null;

	private void Start()
	{
		_tipText.text = _tipTextSO.tipTextList[(int)StageManager.Instance.CurrentStageType];
	}
}
