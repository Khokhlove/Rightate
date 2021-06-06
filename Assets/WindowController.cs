using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public GameObject yesNoWindow;

    private static WindowController instance;

    private void Awake()
    {
        instance = this;
    }

    public static WindowController GetInstance()
    {
        return instance;
    }

    public YesNoWindowUI CreateYesNoWindow(string text)
    {
        GameObject instance = Instantiate(yesNoWindow, transform);
        YesNoWindowUI yesNoWindowUI = instance.GetComponent<YesNoWindowUI>();
        yesNoWindowUI.SetText(text);

        return yesNoWindowUI;
    }
}
