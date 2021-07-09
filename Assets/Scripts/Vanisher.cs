using System;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vanisher : Singleton<Vanisher>
{
    CanvasGroup canvasGroup;
    
    [Range(0, 1)] public float startAlpha;
    [Range(0, 1)] public float targetAlpha;

    public GameObject cassette;

    public override void Awake()
    {
        base.Awake();
        canvasGroup = GetComponent<CanvasGroup>();
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
        canvasGroup.alpha = startAlpha;
    }

    public void InstantHide()
    {
        canvasGroup.alpha = targetAlpha;
    }

    IEnumerator _Hide(Action callback)
    {
        float lerp = 0;
        while (lerp < 1)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, lerp);
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
            canvasGroup.alpha = Mathf.Lerp(targetAlpha, startAlpha, lerp);
            lerp += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        callback();
    }

    public void VanishAndLoad()
    {
        cassette.SetActive(true);
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
            Show(() => { cassette.SetActive(false); });
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
        cassette.SetActive(false);
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