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
        if (adManager.InterstatialAdManager.IsInterstatialAdReady())
        {

            adManager.InterstatialAdManager.RegisterOnAdClosedEvent(OnAdClosed);
            adManager.InterstatialAdManager.ShowAd();
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }

 
    private void OnAdClosed(IronSourceAdInfo info)
    {
        adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);

        SceneManager.LoadScene("Game");
        adManager.InterstatialAdManager.LoadAds();
    }
}
