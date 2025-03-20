using System;
using System.Collections.Generic;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winningWindow : MonoBehaviour
{
    public RTLTextMeshPro timerText;
    public float progress = 0;
    public float currentTime;
    public float targetTime;
    public int coins;
    public Sprite fillStarBig;
    public Sprite fillStarSmall;
    public RTLTextMeshPro coinsText;
    public List<Image> starsBig = new List<Image>();
    public List<Image> starsSmall = new List<Image>();

    string sceneName;
    int starsNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.stopTimer = true;
        currentTime = GameManager.Instance.currentTime;
        targetTime = GameManager.Instance.targetTime;
        float timeDisplay = GameManager.Instance.currentTime;
        float seconds = (int)(timeDisplay % 60);
        float minutes = (int)(timeDisplay / 60);

        timerText.text = "الوقت: " + string.Format("{0:0}:{1:00}", minutes, seconds);
        coinsText.text = "+" + coins;
        int PlayerCoins = PlayerPrefs.GetInt("PlayerCoins");
        PlayerPrefs.SetInt("PlayerCoins", PlayerCoins + coins);
        PlayerPrefs.Save();

        sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("PlayerStage" + sceneName, sceneName);
        PlayerPrefs.Save();

        //calculate the number of hearts to the normalization formula
        float numberOfHeart = 3 / GameManager.Instance.heartNum;

        if (!GameManager.Instance.TimerForLose)
        {
            progress = 1.0f / numberOfHeart;
            Debug.Log("progress: " + progress);

        }
        else
        {
            progress = (GameManager.Instance.currentTime / GameManager.Instance.targetTime) - (numberOfHeart * 0.1f);
            Debug.Log("progress: " + progress);
        }

        Stars();
    }
    public void Stars()
    {
        if (progress < 0.4f)
        {
            for (int i = 0; i < 1; i++)
            {
                starsBig[i].sprite = fillStarBig;
                starsSmall[i].sprite = fillStarSmall;
            }
            starsNum = 1;
        }
        else if (progress < 0.6f)
        {
            for (int i = 0; i < 2; i++)
            {
                starsBig[i].sprite = fillStarBig;
                starsSmall[i].sprite = fillStarSmall;
            }
            starsNum = 2;
        }
        else if (progress >= 0.6)
        {
            for (int i = 0; i < 3; i++)
            {
                starsBig[i].sprite = fillStarBig;
                starsSmall[i].sprite = fillStarSmall;
            }
            starsNum = 3;
        }

        PlayerPrefs.SetInt("StarsForDoor" + PlayerPrefs.GetString("PlayerStage" + sceneName), starsNum);
        PlayerPrefs.Save();
    }

    public void GateScene()
    {
        SceneManager.LoadScene("Gates");
        //sound
        SoundManager.PlaySound(SoundType.Buttons);
    }
}
