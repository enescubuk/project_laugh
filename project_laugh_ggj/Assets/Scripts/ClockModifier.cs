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
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private GameObject handler;
    private float _currentTime;
    [SerializeField] private float _duration;
    void Start()
    {
        _currentTime = _duration;
        _timeText.text = _currentTime.ToString();
        StartCoroutine(CountdownTime());
    }

    private IEnumerator CountdownTime()
    {
        while (_currentTime >= 0)
        {
            Debug.Log(_time.fillAmount * 360);
            _time.fillAmount = Mathf.InverseLerp(0, _duration, _currentTime);
            _timeText.text = _currentTime.ToString();
            handler.transform.eulerAngles = new Vector3(0, 0,_time.fillAmount* 360f);
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }
        yield return null;
    }

}
