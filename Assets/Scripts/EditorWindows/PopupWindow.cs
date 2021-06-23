using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PopupWindow : EditorWindow
{
    public string title;
    public string body;
    public string buttonText;

    public static void Show(string title, string body, string buttonText)
    {
        PopupWindow window = ScriptableObject.CreateInstance<PopupWindow>();
        window.title = title;
        window.body = body;
        window.buttonText = buttonText;
        window.titleContent = new GUIContent() { text = title };

        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowUtility();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField(body, new GUIStyle() { alignment = TextAnchor.MiddleCenter});
        GUILayout.Space(20);
        if (GUILayout.Button(buttonText)) this.Close();
    }
}
