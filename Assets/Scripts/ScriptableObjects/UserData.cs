using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : ScriptableObject
{
    public int userId = 0;

    static UserData instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }    
    }

    public static UserData GetInstance()
    {
        return instance;
    }

    void Start()
    {
        if (userId == 0)
        {
            userId = Random.RandomRange(0, 999999999);
        }
    }
}
