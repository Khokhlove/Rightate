using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : Singleton<GameSettings>
{
    public override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = 120;
    }
}
