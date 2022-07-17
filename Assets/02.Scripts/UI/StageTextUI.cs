using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageTextUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text = null;

    // Start is called before the first frame update
    void Start()
    {
        _text.text = $"{(int)StageManager.Instance.CurrentStageType} / {(int)StageType.Count - 1}";
    }
}
