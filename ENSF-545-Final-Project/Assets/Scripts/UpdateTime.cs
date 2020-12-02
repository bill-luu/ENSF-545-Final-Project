using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UpdateTime : MonoBehaviour
{
    void Start()
    {
        Timer.Reset();
    }
    // Update is called once per frame
    void Update()
    {
        Timer.AddTime(Time.deltaTime);
    }
}
