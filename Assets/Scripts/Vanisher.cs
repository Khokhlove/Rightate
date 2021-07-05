﻿using System;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vanisher : Singleton<Vanisher>
{
    Material material;

    public Color startColor;
    public Color targetColor;

    public override void Awake()
    {
        base.Awake();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }

    public void Hide(Action callback)
    {
        StartCoroutine(_Hide(() =>
        {
            callback();
        }));
    }

    public void Show(Action callback)
    {
        StartCoroutine(_Show(() =>
        {
            callback();
        }));
    }

    public void InstantShow()
    {
        material.color = startColor;
    }

    public void InstantHide()
    {
        material.color = targetColor;
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

            StartCoroutine(LoadClip(() =>
            {
                SceneManager.sceneLoaded += OnSceneLoaded;
                LevelLoader.GetInstance().LoadLevel();
            }));
        });

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Show(() => { });
        }

        IEnumerator LoadClip(Action callback)
        {
            AudioClip clip = MusicContainer.GetInstance().selected.track;
            clip.LoadAudioData();
            
            while(clip.loadState == AudioDataLoadState.Loading)
            {
                yield return new WaitForEndOfFrame();
            }

            callback();
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
        }
    }

}