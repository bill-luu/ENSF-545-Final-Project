using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        SetTimerText();
    }

    void SetTimerText()
    {
        timerText.text = "Time: " + Timer.GetTimeText;
    }
}
