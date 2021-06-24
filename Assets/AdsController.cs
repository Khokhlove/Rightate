using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RewardedAds))]
public class AdsController : MonoBehaviour
{
    public CustomInt gamesBeforeAd;
    public int threshold = 2;
    RewardedAds rewardedAds;

    void Start()
    {
        rewardedAds = GetComponent<RewardedAds>();
    }

    public void Dcr()
    {
        if (gamesBeforeAd.value - 1 == 0)
        {
            rewardedAds.ShowRewardedVideo();
            gamesBeforeAd.value = threshold;
            return;
        }

        gamesBeforeAd.value -= 1;
    }
}