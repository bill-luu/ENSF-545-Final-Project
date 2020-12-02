using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Timer
{
    static float timer = 0.0f;

    public static void AddTime(float seconds)
    {
        timer += seconds;
    }

    public static String GetTimeText
    {
        get {
            var ss = (timer % 60).ToString("00.000");
            var mm = (Math.Floor((timer / 60)) % 60).ToString("00");
            return mm + ":" + ss;
        }

    }

    public static void Reset()
    {
        timer = 0.0f;
    }
}
