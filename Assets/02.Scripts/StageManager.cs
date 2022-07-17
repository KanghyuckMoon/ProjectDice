using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : Singleton<StageManager>
{
	public StageType CurrentStageType
	{
		get
		{
			return _stageType;
		}
	}

	private StageType _stageType = StageType.Stage1;
	private List<IObserver> _observers = new List<IObserver>();

	private void Start()
	{
		SceneManager.sceneLoaded += LoadSceneInit;
	}

	/// <summary>
	/// ������ �߰�
	/// </summary>
	/// <param name="observer"></param>
	public void AddObserver(IObserver observer)
	{
		_observers.Add(observer);
	}

	private void LoadSceneInit(Scene arg0, LoadSceneMode arg1)
	{
		_observers.Clear();
	}



	/// <summary>
	/// ���� ���������� �̵�
	/// </summary>
	public void NextStage()
	{
		Delivery();
		StartCoroutine(SceneMove());
	}


	/// <summary>
	/// �������� Ŭ���� ����
	/// </summary>
	public void Delivery()
	{
		foreach (var observer in _observers)
		{
			observer.Notice();
		}
	}


	/// <summary>
	/// �� �̵�
	/// </summary>
	/// <returns></returns>
	private IEnumerator SceneMove()
	{
		yield return new WaitForSeconds(3);

		_stageType = (StageType)((int)_stageType + 1);
		if (_stageType == StageType.Count || _stageType == StageType.None)
		{
			_stageType = StageType.Stage1;
		}
		SceneManager.LoadScene(_stageType.ToString());
	}
}
