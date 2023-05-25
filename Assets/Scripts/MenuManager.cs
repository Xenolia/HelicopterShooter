using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {


	public string RateUsUrl,MoreGamesURL;
	public Text CurrentLevelText,Totalcoins;
    [Header("Share")]
    public string Subject;
    public string Body;

    int CurrentLevel;
    int coins;

    [SerializeField] AdManager adManager;

    private void Awake()
    {
        adManager.Init();
     }

    // Use this for initializatino
    void Start () {
      
            CurrentLevel = PlayerPrefs.GetInt("Level", 0);
            CurrentLevelText.text = "MISSION: " + (CurrentLevel+1);
        Totalcoins.text = "$" + PlayerPrefs.GetInt("COINS", 0);
        
	}


	public void LoadLevel(){
        if (adManager.InterstatialAdManager.IsInterstatialAdReady())
        {
            adManager.InterstatialAdManager.RegisterOnAdClosedEvent(OnAdClosed);
            adManager.InterstatialAdManager.ShowAd();
        }
	}

    private void OnAdClosed(IronSourceAdInfo info)
    {
        adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
        SceneManager.LoadScene("Game");

    }

    public void RateUs ()
	{
      //  Application.OpenURL(RateUsUrl);

    }


    public void MoreGames(){

	//	Application.OpenURL (MoreGamesURL);
	}


    public void Restart()
    {

        if (adManager.InterstatialAdManager.IsInterstatialAdReady())


        {
            adManager.InterstatialAdManager.ShowAd();
        }
        SceneManager.LoadScene("Game");
    }

    public void Home()
    {

        if (adManager.InterstatialAdManager.IsInterstatialAdReady())


        {
            adManager.InterstatialAdManager.ShowAd();
        }
        SceneManager.LoadScene("Menu");

    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");

    }

    public void ShareClick()
    {
        StartCoroutine(StartShare());
    }

    IEnumerator StartShare()
    {
        yield return new WaitForEndOfFrame();
        new NativeShare().SetSubject(Subject).SetText(Body).Share();
    }



}
