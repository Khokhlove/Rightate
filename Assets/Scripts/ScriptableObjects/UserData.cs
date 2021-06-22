using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "UserData")]
public class UserData : ScriptableObject
{
    public int userId = 0;

    void Awake()
    {
        if (userId == 0)
        {
            userId = Random.Range(0, 999999999);
        }
    }
}
