using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {

    public float totalTime;
    public TextMeshProUGUI timeText;

    public event Action OnTimerOver;

    private bool timerStarted;
    private float timeRemaining;

    

    private void Awake()
    {
        timeRemaining = totalTime;
        timeText.text = "Time:\n" + secToString(timeRemaining);
    }


    private void Update()
    {
        if (timerStarted && timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;

            timeText.text = "Time:\n" + secToString(timeRemaining);

            if (timeRemaining < totalTime * 0.2f)
            {
                timeText.color = Color.red;
            }
        }
        else
        {
            ResetTimer();
        }
    }


    private string secToString(float secRem)
    {
        int min = (int)(secRem / 60f);
        int sec = (int)secRem % 60;
        int milisec = (int)((secRem - (float)(int)(secRem))*100);

        return min.ToString("00")+":"+sec.ToString("00") + ":" + milisec.ToString("00");
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void ResetTimer()
    {
        //通知收听method，timer结束。
        if(OnTimerOver != null)OnTimerOver();
        //重置剩余时间。
        timeRemaining = totalTime;
        //标记为未启动。
        timerStarted = false;
        //清空时间结束观众席。
        OnTimerOver = null;
        //重置颜色和显示时间。
        timeText.color = Color.white;
        timeText.text = "Time:\n" + secToString(timeRemaining);
    }
}
