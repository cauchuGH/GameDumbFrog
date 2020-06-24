using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SC_StartGame : MonoBehaviour
{
    public GameObject pnlhighScore;
    public Text txtFistHC;
    public Text txtSecondHC;
    public Text txtThirdHC;

    public GameObject btnStart;
    public GameObject btnWatchHS;

    // Start is called before the first frame update
    void Start()
    {
        pnlhighScore.SetActive(false);
        btnStart.SetActive(true);
        btnWatchHS.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void WatchHighScore()
    {
        Time.timeScale = 0;
        pnlhighScore.SetActive(true);

        txtFistHC.text = PlayerPrefs.GetInt("1").ToString();
        txtSecondHC.text = PlayerPrefs.GetInt("2").ToString();
        txtThirdHC.text = PlayerPrefs.GetInt("3").ToString();

        btnStart.SetActive(false);
        btnWatchHS.SetActive(false);
    }

    public void BackScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
