using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FPSCounter))]
public class FPSCounterUI : MonoBehaviour
{
    FPSCounter fpsCounter;

    private void Start()
    {
        fpsCounter = GetComponent<FPSCounter>();
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = (h * 2 / 100) * 2;
        style.normal.textColor = new Color(1f, 1f, 1f, 1.0f);
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", fpsCounter.msec, fpsCounter.fps);
        GUI.Label(rect, text, style);
    }
}
