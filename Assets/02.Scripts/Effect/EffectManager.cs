using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EffectManager : Singleton<EffectManager>
{
    private Dictionary<EffectType, Transform> _effectParents = new Dictionary<EffectType, Transform>();
    private Dictionary<EffectType, GameObject> _effectPrefebs = new Dictionary<EffectType, GameObject>();
    private bool _isInit = false;
    
    public override void Awake()
    {
        base.Awake();
        _effectParents.Clear();
        _effectPrefebs.Clear();
        Init();
    }


    /// <summary>
    /// �ʱ�ȭ
    /// </summary>
    private void Init()
    {
        if(_isInit)
        {
            return;
        }
        _isInit = true;

        int count = (int)EffectType.Count;
        for (int i = 0; i < count; ++i)
        {
            GameObject obj = new GameObject(((EffectType)i).ToString());
            DontDestroyOnLoad(obj);
            _effectParents.Add((EffectType)i, obj.transform);
            _effectPrefebs.Add((EffectType)i, AddressablesManager.Instance.GetResource<GameObject>(((EffectType)i).ToString()));

        }
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    /// <summary>
    /// ����Ʈ ��ġ
    /// </summary>
    /// <param name="pos"></param>
    public void SetEffect(EffectType effectType, Vector3 pos)
    {
        if(!_isInit)
        {
            Init();
        }

        GameObject effect = Pool(effectType);
        effect.transform.position = pos;
        effect.gameObject.SetActive(true);
    }

    /// <summary>
    /// �� �̵��� �����Ͽ� ����Ʈ ����
    /// </summary>
    public void MoveSceneToDeleteEffect()
    {
        int count = (int)EffectType.Count;
        for(int i = 0; i < count; ++i)
        {
            Transform parent = _effectParents[(EffectType)i];
            int childCount = parent.childCount;
            for(int j = 0; j < childCount; ++j)
            {
                parent.GetChild(j).gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// ����Ʈ Ǯ��
    /// </summary>
    /// <param name="transform"></param>
    private GameObject Pool(EffectType effectType)
    {
        Transform parent = _effectParents[effectType];
        int count = parent.childCount;
        for (int i = 0; i < count; ++i)
        {
            GameObject effect = parent.GetChild(i).gameObject;
            if (!effect.activeSelf)
            {
                return effect;
            }
        }

        GameObject newEffect = Instantiate(_effectPrefebs[effectType], parent);
        return newEffect;
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        MoveSceneToDeleteEffect();
    }
}
