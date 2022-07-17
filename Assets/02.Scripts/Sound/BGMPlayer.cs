using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField]
    private bool _isPlayerOnAwake = false;
    [SerializeField]
    private AudioBGMType _audioBGMType = AudioBGMType.Count;

    // Start is called before the first frame update
    void Start()
    {
        if (_isPlayerOnAwake)
        {
            PlayBGM();
        }

    }

    private void PlayBGM()
    {
        SoundManager.Instance.PlayBGM(_audioBGMType);
    }
}
