using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : Singleton<PlayManager>
{
	public bool IsStart
	{ 
		get
		{
			return _isStart;
		}
	}

	private bool _isStart = false;
	private List<IObserver> _observers = new List<IObserver>();

	public override void Awake()
	{
		base.Awake();
		SceneManager.sceneLoaded += LoadSceneInit;
		InitGame();
	}

	/// <summary>
	/// 스테이지 초기화
	/// </summary>
	/// <param name="scene"></param>
	/// <param name="mode"></param>
	public void LoadSceneInit(Scene scene, LoadSceneMode mode)
	{
		InitGame();
	}

	/// <summary>
	/// 관찰자 추가
	/// </summary>
	public void AddObserver(IObserver observer)
	{
		_observers.Add(observer);
	}

	/// <summary>
	/// 게임 시작
	/// </summary>
	public void OnPlay()
	{
		_isStart = true;
		foreach(var observer in _observers)
		{
			observer.Notice();
		}
	}

	/// <summary>
	/// 스테이지 초기화
	/// </summary>
	public void InitGame()
	{
		_observers.Clear();
		_isStart = false;
	}

	/// <summary>
	/// 스테이지 리셋
	/// </summary>
	public void ResetGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
