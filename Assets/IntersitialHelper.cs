using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntersitialHelper : MonoBehaviour
{

    AdManager adManager;
    private void Awake()
    {
        adManager = GetComponent<AdManager>();
    }
    public void ShowIntersitial()
    {
        adManager.InterstatialAdManager.ShowAd();
    }
    public void LoadLevelWithIntersitial()
    {
        if(!adManager)
        {
            adManager = GetComponent<AdManager>();
        }
         if (adManager.InterstatialAdManager.IsInterstatialAdReady())
        {
            adManager.InterstatialAdManager.RegisterOnAdShowFailedEvent(OnAdClosed2);
            adManager.InterstatialAdManager.RegisterOnAdLoadFailedEvent(OnAdClosed3);
            adManager.InterstatialAdManager.RegisterOnAdClosedEvent(OnAdClosed);
 
            adManager.InterstatialAdManager.ShowAd();
        } 
            SceneManager.LoadScene("Game"); 
    }
 
    private void OnAdClosed3(IronSourceError arg1)
    {
        adManager.InterstatialAdManager.UnRegisterOnAdShowFailedEvent(OnAdClosed2);
        adManager.InterstatialAdManager.UnRegisterOnAdLoadFailedEvent(OnAdClosed3);

        adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
         
    }
    private void OnAdClosed2(IronSourceError arg1, IronSourceAdInfo arg2)
    {
        adManager.InterstatialAdManager.UnRegisterOnAdShowFailedEvent(OnAdClosed2);
        adManager.InterstatialAdManager.UnRegisterOnAdLoadFailedEvent(OnAdClosed3);

        adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
         
     }

    private void OnAdClosed(IronSourceAdInfo info)
    {
        adManager.InterstatialAdManager.UnRegisterOnAdShowFailedEvent(OnAdClosed2);
        adManager.InterstatialAdManager.UnRegisterOnAdLoadFailedEvent(OnAdClosed3);

        adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
         
     }
}
