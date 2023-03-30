using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text CurrentLevelText, Totalcoins;
    int CurrentLevel;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        if (SceneManager.GetActiveScene().name == "GameWin")
        {
            CurrentLevelText.text = "MISSION: " + (CurrentLevel);
        }
        else {
            CurrentLevelText.text = "MISSION: " + (CurrentLevel + 1);

        }
        Totalcoins.text = "$" + PlayerPrefs.GetInt("COINS", 0);
        // PlayerPrefs.SetInt("Level", (CurrentLevel + 1));
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu() { SceneManager.LoadScene("Menu"); }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");

    }
    public void Restart()
    {

        SceneManager.LoadScene("Game");
    }
}
