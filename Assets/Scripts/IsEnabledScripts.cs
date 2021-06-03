﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnabledScripts : MonoBehaviour
{
    public CustomTimer.Timer timer;

    private void Start()
    {
        timer.timeIsUp.AddListener(OnScriptsEnabled);
    }
    void OnScriptsEnabled()
    {
        timer.enabled = false;
    }
}
