using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text txtPoint;
    int point;

    public GameObject pnlEndgame;
    public Text txtEndPoint;
    public Text txtmaxPoint;
    public Button btnRestart;
    public Button btnExit;

    public AudioClip bgAudio;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        txtmaxPoint.text = PlayerPrefs.GetInt("1").ToString(); // lay thong tin maxScore
        pnlEndgame.SetActive(false);
        
        // quan ly Audio
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = bgAudio;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetPoint()
    {
        point++;
        txtPoint.text = point.ToString();
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void EndGame()
    {
        audioSource.Pause();// dung nhac
        Time.timeScale = 0;
        pnlEndgame.SetActive(true);
        txtEndPoint.text = ("Your Poin\n") + point.ToString();
        SaveGame();
        
    }

    public void SaveGame()
    {
        int fist = PlayerPrefs.GetInt("1");
        int second = PlayerPrefs.GetInt("2");
        int third = PlayerPrefs.GetInt("3");
        if( point >= fist)
        {
            PlayerPrefs.SetInt("3", second);
            PlayerPrefs.SetInt("2", fist);
            PlayerPrefs.SetInt("1", point);
        }
        else if(point >= second)
        {
            PlayerPrefs.SetInt("3", second);
            PlayerPrefs.SetInt("2", point);
        } else if(point >= third)
        {
            PlayerPrefs.SetInt("3", point);
        }

    }

}
