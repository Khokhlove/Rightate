using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesNoWindowUI : MonoBehaviour
{
    public Text text;
    public Button yes;
    public Button no;

    public void SetText(string text)
    {
        this.text.text = text;
    }
}
