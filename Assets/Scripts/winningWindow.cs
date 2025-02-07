using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winningWindow : MonoBehaviour
{
    public TMP_Text timerText;
    public float progress = 0;
    public float currentTime;
    public float targetTime;
    public Sprite fillStar;
    public List<Image> stars = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.stopTimer = true;
        currentTime = GameManager.Instance.currentTime;
        targetTime = GameManager.Instance.targetTime;
        float timeDisplay = GameManager.Instance.currentTime;
        float seconds = (int)(timeDisplay % 60);
        float minutes = (int)(timeDisplay / 60);

        timerText.text = "Timing: " + string.Format("{0:0}:{1:00}", minutes, seconds);

        int PlayerCoins = PlayerPrefs.GetInt("PlayerCoins");
        PlayerPrefs.SetInt("PlayerCoins", PlayerCoins + 100);
        PlayerPrefs.Save();

        Scene m_Scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt("PlayerStage", Convert.ToInt32(m_Scene.name));
        PlayerPrefs.Save();

        if (GameManager.Instance.isStarProgressJustHeart)
            progress = 1.0f / GameManager.Instance.heartNum;

        else
            progress = (GameManager.Instance.currentTime / GameManager.Instance.targetTime) - (GameManager.Instance.heartNum * 0.1f);

        Stars();
    }
    public void Stars()
    {
        if (progress < 0.4f)
        {
            for (int i = 0; i < 1; i++)
            {
                stars[i].sprite = fillStar;
            }
        }
        else if (progress < 0.7f)
        {
            for (int i = 0; i < 2; i++)
            {
                stars[i].sprite = fillStar;
            }
        }
        else if (progress >= 0.7)
        {
            for (int i = 0; i < 3; i++)
            {
                stars[i].sprite = fillStar;
            }
        }
    }

    public void GateScene()
    {
        SceneManager.LoadScene("Gates");
    }
}
