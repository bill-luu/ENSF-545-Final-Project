using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 0.0f;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        SetTimerText();
    }

    void SetTimerText()
    {
        var ss = (timer % 60).ToString("00.000");
        var mm = (Math.Floor((timer / 60)) % 60).ToString("00");
        timerText.text = "Time: " + mm + "." + ss;
    }
}
