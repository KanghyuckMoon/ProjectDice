using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : Singleton<StageManager>
{
	private StageType _stageType = StageType.None;

	/// <summary>
	/// 다음 스테이지로 이동
	/// </summary>
	public void NextStage()
	{
		_stageType = (StageType)((int)_stageType + 1);
		if(_stageType == StageType.Count || _stageType == StageType.None)
		{
			_stageType = StageType.Stage1;
		}
		SceneManager.LoadScene(_stageType.ToString());
	}
}
