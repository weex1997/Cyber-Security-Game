using System;
using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float targetTime = 60.0f;
    public float currentTime;
    public Image filled;
    public List<Image> Hearts = new List<Image>();
    public int heartNum = 3;
    public bool stopTimer = false;
    public Sprite emptySprite;
    public GameObject loseScreen;
    public GameObject winningScreen;
    public TMP_Text timeText;
    public int dialogueCount = 0;
    public bool itsLose = false;
    public bool itsWin = false;

    [Tooltip("if the timer of the game for lose or for win")]
    public bool TimerForLose;
    public bool itExitButton = false;
    public GameObject playerHint;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    void Start()
    {
        currentTime = targetTime;

        //level time analysis
        PlayerData.Instance.totalTime.customTime = 0;
        PlayerData.Instance.totalTime.startCustomTime = true;

    }
    void Update()
    {
        if (!stopTimer)
        {
            currentTime -= Time.deltaTime;
            filled.fillAmount = currentTime / targetTime;
            var ts = TimeSpan.FromSeconds(currentTime);
            timeText.text = string.Format("{0:0}:{1:00}", ts.TotalMinutes, ts.Seconds);
            if (currentTime <= 0.0f)
            {
                timerEnded();
            }
        }

    }
    void timerEnded()
    {
        stopTimer = true;

        checkEndTheGame();
    }
    public void checkEndTheGame()
    {
        if (heartNum <= 0 || (stopTimer && TimerForLose))
            Losing();
        else
            Winning();
    }
    public void LoseHeart(int damage)
    {
        //sound
        if (SoundManager.instance != null)
            SoundManager.PlaySound(SoundType.LoseHeart);
        if (damage < Hearts.Count)
            Hearts[heartNum - damage].sprite = emptySprite;
        heartNum -= damage;
        if (heartNum <= 0)
        {
            Losing();
        }
    }
    public void Losing()
    {

        //level time analysis
        if (PlayerData.Instance != null)
            PlayerData.Instance.totalTime.startCustomTime = false;

        stopTimer = true;
        if (loseScreen != null)
            loseScreen.SetActive(true);
        itsLose = true;
        //sound
        if (SoundManager.instance != null)
            SoundManager.PlaySound(SoundType.Lose);

    }
    public void Winning()
    {
        //level time analysis
        PlayerData.Instance.totalTime.startCustomTime = false;

        stopTimer = true;
        winningScreen.SetActive(true);
        itsWin = true;

        //sound
        SoundManager.PlaySound(SoundType.Win);
    }
    public void StartHint(string hintText)
    {
        playerHint.GetComponent<RTLTextMeshPro>().text = hintText;
        StartCoroutine(_StartHint());
    }
    IEnumerator _StartHint()
    {
        playerHint.SetActive(true);
        yield return new WaitForSeconds(5f);
        playerHint.SetActive(false);
    }
    void SaveDataAnalytics()
    {


        float levelTime = PlayerData.Instance.totalTime.customTime;
        string levelName = SceneManager.GetActiveScene().name;

        int levelAtempt = PlayerPrefs.GetInt("Level" + levelName + "Atempt") + 1;
        PlayerPrefs.SetInt("Level" + levelName + "Atempt", levelAtempt);
        Debug.Log("Level" + levelName + "Atempt" + levelAtempt);


        PlayerData.Instance.AnalyticsLevelTime(levelName, levelTime);
        PlayerPrefs.SetFloat("Level" + levelName + "Time", levelTime);
    }
    void OnDestroy()
    {
        if (!itExitButton)
            SaveDataAnalytics();
    }

}
