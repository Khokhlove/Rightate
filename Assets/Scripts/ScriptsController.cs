using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsController : MonoBehaviour
{
    public CustomTimer.Timer timer;
    public SwipeEventHandler swipeHandler;


    private void Start()
    {
        timer.timeIsUp.AddListener(DisableScripts);
    }
    void DisableScripts()
    {
        timer.enabled = false;
        swipeHandler.enabled = false;
    }
}
