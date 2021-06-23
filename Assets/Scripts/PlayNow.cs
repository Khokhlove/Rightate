using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayNow : MonoBehaviour
{
    public void LoadMenu()
    {
        Vanisher.GetInstance().VanishAndLoadMenu();
    }
    public void LoadGame()
    {
        Vanisher.GetInstance().VanishAndLoad();
    }
}