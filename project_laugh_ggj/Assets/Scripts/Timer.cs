using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerLeft;
    bool timerOn = false;
    public bool dayEnd;

    [SerializeField] TMP_Text timerText;

    private void Start()
    {
        timerOn = true;
        dayEnd = false;
    }

    private void Update()
    {
        updateTimer(timerLeft);
        if (timerOn)
        {
            if (timerLeft > 0)
            {
                timerLeft -= Time.deltaTime;
            }
            else
            {
                timerLeft = 0;
                timerOn = false;
                dayEnd = true;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
       
    }

}
