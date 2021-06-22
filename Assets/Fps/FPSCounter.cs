using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour
{
	public float fps = 0;
	public float msec = 0;
	float deltaTime = 0.0f;

	static FPSCounter instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
	}

	public static FPSCounter GetInstance()
    {
		return instance;
    }

	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		msec = deltaTime * 1000.0f;
		fps = 1.0f / deltaTime;
	}
}
