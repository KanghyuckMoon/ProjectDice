using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    [SerializeField]
    private float _duration;

    private void OnEnable()
    {
        StartCoroutine(Delete());
    }
    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(_duration);
        gameObject.SetActive(false);
    }

}
