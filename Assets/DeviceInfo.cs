using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class DeviceInfo : Singleton<DeviceInfo>
{
    public string hostName = "192.168.0.99";
    public int port = 80;
    public string deviceId = "";

    void Start()
    {
        deviceId = GetDeviceId();
        Dictionary<string, string> dictFields = new Dictionary<string, string>();
        Type sysInfo = typeof(SystemInfo);
        PropertyInfo[] fields = sysInfo.GetProperties();
        foreach (var p in fields)
        {
            dictFields.Add(p.Name, p.GetValue(sysInfo).ToString());
        }

        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("deviceId", deviceId);

        string deviceInfo = JsonConvert.SerializeObject(dictFields);
        dict.Add("deviceInfo", deviceInfo);

        string json = JsonConvert.SerializeObject(dict);

        StartCoroutine(SendDeviceInfo(json));
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        Application.wantsToQuit += () =>
        {
            Scene activeScene = SceneManager.GetActiveScene();
            SendPrefomanceInfo(activeScene, Application.Quit);
            return false;
        };
    }

    private void OnSceneUnloaded(Scene scene)
    {
        SendPrefomanceInfo(scene, () => { });
    }

    void SendPrefomanceInfo(Scene scene, Action callback)
    {
        FPSCounter fpsCounter = FPSCounter.GetInstance();
        Dictionary<string, string> temp = new Dictionary<string, string>()
        {
            { "deviceId", deviceId},
            { "version", Application.version},
            { "levelName", scene.name },
            { "fps",  fpsCounter.fps.ToString()},
            { "meanFps", fpsCounter.meanFps.ToString() }
        };

        StartCoroutine(_SendPerfomanceInfo(JsonConvert.SerializeObject(temp), callback));
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

    IEnumerator _SendPerfomanceInfo(string json, Action callback)
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

        callback();
    }

    string GetDeviceId()
    {
        List<byte> bytes = new List<byte>();
        string info = $"{SystemInfo.deviceName}_{SystemInfo.deviceType}_{SystemInfo.deviceModel}_{SystemInfo.processorType}";

        foreach (char c in info)
        {
            bytes.Add((byte)c);
        }

        return CRC32.GetCRC32(bytes.ToArray()).ToString("X2");
    }
}
