using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardShop : MonoBehaviour
{
    AdManager adManager;


    [SerializeField] AdManager _adManager;
    private void Awake()
    {
        _adManager = FindObjectOfType<AdManager>();
 
    }
    public void ShowRewardAd()
    {
        _adManager = FindObjectOfType<AdManager>();

        if (_adManager.RewardedAdManager.IsRewardedAdReady())
        {
            _adManager.RewardedAdManager.RegisterOnUserEarnedRewarededEvent(OnUserEarnedReward);
            _adManager.RewardedAdManager.RegisterOnAdClosedEvent(OnRewardedAdClosed);

            ShowRewardedAd();
        }
    }
    private void OnRewardedAdClosed(IronSourceAdInfo info)
    {
        _adManager.RewardedAdManager.UnRegisterOnUserEarnedRewarededEvent(OnUserEarnedReward);
        _adManager.RewardedAdManager.UnRegisterOnAdClosedEvent(OnRewardedAdClosed); 
    }
    private void OnUserEarnedReward(IronSourcePlacement placement, IronSourceAdInfo info)
    {
        RewardEarned();
    }

    private void ShowRewardedAd()
    {

        _adManager.RewardedAdManager.ShowAd();
    }
    public void ShowRewarded()
    {
        ShowRewardAd();
    }
    public void RewardEarned()
    {
        Debug.Log("Reward earned");
        PlayerPrefs.SetInt("COINS", PlayerPrefs.GetInt("COINS", 0) + 500);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
