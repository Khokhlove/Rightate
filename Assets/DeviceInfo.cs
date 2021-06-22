using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class DeviceInfo : MonoBehaviour
{
    public string hostName = "192.168.0.99";
    public int port = 80;
    public UserData userData;

    const string MENU = "Menu";
    const string GAME = "Game";

    Dictionary<string, int> fpsData = new Dictionary<string, int>()
    {
        { MENU, 0 },
        { GAME, 0}
    };

    static DeviceInfo instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        Dictionary<string, string> dictFields = new Dictionary<string, string>();
        Type sysInfo = typeof(SystemInfo);
        PropertyInfo[] fields = sysInfo.GetProperties();
        foreach (var p in fields)
        {
            dictFields.Add(p.Name, p.GetValue(sysInfo).ToString());
        }

        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("userId", userData.userId.ToString());

        string deviceInfo = JsonConvert.SerializeObject(dictFields);
        dict.Add("deviceInfo", deviceInfo);

        string json = JsonConvert.SerializeObject(dict);

        StartCoroutine(SendDeviceInfo(json));
    }

    // Update is called once per frame
    void Update()
    {
        if (fpsData[MENU] == 0 || fpsData[GAME] == 0)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            fpsData[sceneName] = Convert.ToInt32(FPSCounter.GetInstance().fps);

        } else
        {
            StartCoroutine(Delay(10f, () =>
            {
                Dictionary<string, string> temp = new Dictionary<string, string>()
                {
                    { "deviceId", userData.userId.ToString()},
                    { "menuFPS", fpsData[MENU].ToString() },
                    { "ingameFPS", fpsData[GAME].ToString() }
                };

                StartCoroutine(SendFPS(JsonConvert.SerializeObject(temp)));
                fpsData = new Dictionary<string, int>()
                {
                    { MENU, 0 },
                    { GAME, 0}
                };
            }));
        }
    }

    IEnumerator SendDeviceInfo(string json)
    {
        UnityWebRequest www = UnityWebRequest.Put($"http://{hostName}:{port}/api/deviceInfo", json);
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    IEnumerator Delay(float duration, Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback();
    }

    IEnumerator SendFPS(string json)
    {
        UnityWebRequest www = UnityWebRequest.Put($"http://{hostName}:{port}/api/perfomance", json);
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
