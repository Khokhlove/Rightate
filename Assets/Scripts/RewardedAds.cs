using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class RewardedAds : MonoBehaviour, IUnityAdsListener
{
    public enum SurfacingType { RewardedVideo, InterstitialVideo };
#if UNITY_EDITOR
    public bool testMode = true;
#else
    public bool testMode = false;
#endif
    [SerializeField]
    public UnityAdsDidFinish unityAdsDidFinish;
    public UnityEvent<SurfacingType> unityAdsReady;
    public UnityEvent<SurfacingType> unityAdsDidStart;
    public UnityEvent<string> unityAdsDidError;

#if UNITY_IOS
    private string gameId = "4184564";
#elif UNITY_ANDROID
    private string gameId = "4184565";
#endif

    Dictionary<SurfacingType, string> surfacingIds = new Dictionary<SurfacingType, string>()
    {
        { SurfacingType.RewardedVideo, "rewardedVideo" },
        { SurfacingType.InterstitialVideo, "video" }
    };

    string GetSurfacingId(SurfacingType type)
    {
        return surfacingIds[type];
    }
    private SurfacingType GetSurfacingType(string surfacingId)
    {
        List<string> ids = surfacingIds.Values.ToList();
        int id = surfacingIds.Values.ToList().FindIndex(s => s == surfacingId);
        return (SurfacingType)id;
    }
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowInterstitialVideo()
    {
        string surfacingId = GetSurfacingId(SurfacingType.InterstitialVideo);

        if (Advertisement.IsReady(surfacingId))
        {
            Advertisement.Show(surfacingId);
        }
        else
        {
            Debug.Log("Interstitial video is not ready at the moment! Please try again later!");
        }
    }

    public void ShowRewardedVideo()
    {
        string surfacingId = GetSurfacingId(SurfacingType.RewardedVideo);

        if (Advertisement.IsReady(surfacingId))
        {
            Advertisement.Show(surfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        SurfacingType type = GetSurfacingType(surfacingId);

        unityAdsDidFinish.Invoke(type, showResult);
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        unityAdsReady.Invoke(GetSurfacingType(surfacingId));
    }

    public void OnUnityAdsDidError(string message)
    {
        unityAdsDidError.Invoke(message);
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        unityAdsDidStart.Invoke(GetSurfacingType(surfacingId));
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    [Serializable]
    public class UnityAdsDidFinish : UnityEvent<SurfacingType, ShowResult> { };
}