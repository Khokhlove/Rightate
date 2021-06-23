using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Vanisher : MonoBehaviour
{
    Material material;
    static Vanisher instance;

    public Color startColor;
    public Color targetColor;

    public static Vanisher GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {

    }
    public void Hide(Action callback)
    {
        //gameObject.SetActive(true);
        StartCoroutine(_Hide(() =>
        {
            callback();
            //gameObject.SetActive(false);
        }));
    }

    public void Show(Action callback)
    {
        //gameObject.SetActive(true);
        StartCoroutine(_Show(() =>
        {
            callback();
            //gameObject.SetActive(false);
        }));
    }

    IEnumerator _Hide(Action callback)
    {
        float lerp = 0;
        while (lerp < 1)
        {
            material.color = Color.Lerp(startColor, targetColor, lerp);
            lerp += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        callback();
    }
    IEnumerator _Show(Action callback)
    {
        float lerp = 0;
        while (lerp < 1)
        {
            material.color = Color.Lerp(targetColor, startColor, lerp);
            lerp += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        callback();
    }

    public void VanishAndLoad()
    {
        Hide(() =>
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            LevelLoader.GetInstance().LoadLevel();
        });
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Show(() => { });
        }
    }

    public void VanishAndLoadMenu()
    {
        Hide(() =>
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            LevelLoader.LoadLevel(0);
        });
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Show(() => { });
        }
    }

}