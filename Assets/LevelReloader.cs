using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReloader : MonoBehaviour
{
    public void ReloadLevel()
    {
        LevelLoader.GetInstance().LoadLevel();
    }

}
