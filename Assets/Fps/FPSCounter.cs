using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FPSCounter : Singleton<FPSCounter>
{
	public float fps = 0;
    public float meanFps;
	public float msec = 0;

	float deltaTime = 0.0f;
    List<float> fpsList = new List<float>();

    void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		msec = deltaTime * 1000.0f;
		fps = 1.0f / deltaTime;
        fpsList.Add(fps);
        meanFps = fpsList.Sum() / fpsList.Count;
	}
}
