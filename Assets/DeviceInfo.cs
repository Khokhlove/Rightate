using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class DeviceInfo : MonoBehaviour
{
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
        dict.Add("userId", UnityEngine.Random.Range(0, 99999999).ToString());

        string deviceInfo = JsonConvert.SerializeObject(dictFields);
        dict.Add("deviceInfo", deviceInfo);

        string json = JsonConvert.SerializeObject(dict);

        StartCoroutine(SendDeviceInfo(json));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SendDeviceInfo(string json)
    {
        UnityWebRequest www = UnityWebRequest.Put("http://localhost:80/api/deviceInfo", json);
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
