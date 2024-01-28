using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using TMPro;

public class ClockModifier : MonoBehaviour
{
    [SerializeField] private Image _time;
    [SerializeField] private GameObject handler;
    public float _currentTime;
    [SerializeField] private float _duration;
    void Start()
    {
        _currentTime = _duration;
        StartCoroutine(CountdownTime());
    }

private IEnumerator CountdownTime()
{
    while (_currentTime >= 0)
    {
        _time.fillAmount = Mathf.InverseLerp(0, _duration, _currentTime);

        // Zaman tamamken (fillAmount = 1) handler 0 derecede olacak ve zaman azaldıkça (fillAmount azaldıkça) -180 dereceye doğru dönecek.
        handler.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(0, -180, 1 - _time.fillAmount));

        yield return new WaitForSeconds(1f);
        _currentTime--;
    }
    yield return null;
}




}
