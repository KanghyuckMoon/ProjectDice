using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TipTextSO", menuName = "ScriptableObject/TipTextSO", order = int.MaxValue)]
public class TipTextSO : ScriptableObject
{
	public List<string> tipTextList = new List<string>();
}
