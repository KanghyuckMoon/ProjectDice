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
	/// �������� �ʱ�ȭ
	/// </summary>
	/// <param name="scene"></param>
	/// <param name="mode"></param>
	public void LoadSceneInit(Scene scene, LoadSceneMode mode)
	{
		InitGame();
	}

	/// <summary>
	/// ������ �߰�
	/// </summary>
	public void AddObserver(IObserver observer)
	{
		_observers.Add(observer);
	}

	/// <summary>
	/// ���� ����
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
	/// �������� �ʱ�ȭ
	/// </summary>
	public void InitGame()
	{
		_observers.Clear();
		_isStart = false;
	}

	/// <summary>
	/// �������� ����
	/// </summary>
	public void ResetGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
