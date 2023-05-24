using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour {

    public Text infoText;

    void Awake()
    {
        GameMonetize.OnResumeGame += ResumeGame;
        GameMonetize.OnPauseGame += PauseGame;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
        Debug.Log("Resume game");
    }

    public void PauseGame()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
        Debug.Log("Pause game");

    }


    public void ShowAd()
    {
        GameMonetize.Instance.ShowAd();
    }
}
