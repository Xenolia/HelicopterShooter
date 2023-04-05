using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int TotalTarget,targets;
    bool GameEnd;
    int life;
    public Animator DamageVFX;
    int coins;
    public Text Health;
    public Text level;
    public Text CoinText;
    public GameObject Helicopter;
    bool started;

   public int CurrentLevel;
    [Header("Player")]
    public GameObject[] players;

    [Header("Level")]
    public GameObject[] Level;
    // Start is called before the first frame update


    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    void Start()
    {
        started = false;
        CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        level.text = "MISSION " + (CurrentLevel + 1);
        int currentPlayer = PlayerPrefs.GetInt("Player", 0);
        players[currentPlayer].SetActive(true);
        life = 10;
        Health.text = "" + life;
        GameEnd = false;
        coins = 0;
        CoinText.text = "+$" + coins;
        Instantiate(Level[CurrentLevel]);
        float floorCount = Level[CurrentLevel].transform.childCount;
        floorCount = floorCount -2;
        Helicopter.transform.position = new Vector3(0,1.5f + (floorCount*2.5f),0);
        StartCoroutine(DelayStart()); 
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            targets = GameObject.FindGameObjectsWithTag("Enemy").Length;


            if (targets == 0 && !GameEnd)
            {
                GameEnd = true;
                GameWin();

            }
            if (life == 0)
            {
                GameOver();
                GameEnd = true;
            }
        }
    }


    public void GameWin() {

        Time.timeScale = 0.5f;
        Invoke("GameWinDelay",0.5f);
    }
    void GameWinDelay()
    {
        Time.timeScale = 1f;

        PlayerPrefs.SetInt("Level", (CurrentLevel + 1));
        SceneManager.LoadScene("GameWin");
    }
    public void GameOver() {
        Time.timeScale = 0.5f;

        Invoke("GameOverDelay", 0.3f);

    }

    void GameOverDelay()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("GameOver");
    }
    public void Score() {
        if (life == 0)
            return;

        life--;
        DamageVFX.SetTrigger("Hit");
        Health.text = "" + life;

        

        if (life == 1) {
            DamageVFX.SetBool("Die", true);
            //DamageVFX.SetActive(true);
        }
    }

    public void AddMoney() {

        coins += 10;
        PlayerPrefs.SetInt("COINS", PlayerPrefs.GetInt("COINS", 0) + 10);
        CoinText.text = "$" + coins;
    }

    IEnumerator DelayStart() {
        yield return new WaitForSeconds(2.5f);
        started = true;
    }
}
