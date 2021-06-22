using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FPSCounter : MonoBehaviour
{
	public float fps = 0;
    public float meanFps;
	public float msec = 0;

	float deltaTime = 0.0f;
    List<float> fpsList = new List<float>();

	static FPSCounter instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
	}

    private void Start()
    {
        //SceneManager.sceneLoaded
    }

    void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		msec = deltaTime * 1000.0f;
		fps = 1.0f / deltaTime;
        fpsList.Add(fps);
        meanFps = fpsList.Sum() / fpsList.Count;
	}

    public static FPSCounter GetInstance()
    {
        return instance;
    }
}
