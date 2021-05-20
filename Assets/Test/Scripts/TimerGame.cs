using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerGame : MonoBehaviour
{
    [Tooltip("Время отсчета:")]
    public float timer = 60;
    [Tooltip("Количество цифр после запятой:")]
    public int numberRound;
    [Tooltip("TextBox для вывода:")]
    public Text textBox;
    [Tooltip("Объект для включения или отключения по окончанию таймера:")]
    public GameObject obj;

    void Update()
    {
        if (obj != null)
            obj.SetActive(GetEndTimer());
        else
            GetEndTimer();
        textBox.text = System.Math.Round(timer, numberRound).ToString("0.00");
    }

    void CalculationTime()
    {
        timer = timer - Time.deltaTime;
    }

    public float GetTime()
    {
        return timer;
    }

    bool GetEndTimer()
    {
        if (timer == 0 || timer < 0)
        {
            timer = 0;
            return true;
        }
        else
        {
            CalculationTime();
            return false;
        }
    }
}
