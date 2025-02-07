using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float targetTime = 60.0f;
    public float currentTime;
    public Image filled;
    public List<Image> Hearts = new List<Image>();
    public int heartNum = 1;
    public bool stopTimer = false;
    public Sprite emptySprite;
    public GameObject loseScreen;
    public GameObject winningScreen;
    public TMP_Text timeText;
    public int dialogueCount = 0;
    public int loseOrWin = 0;

    public bool isStarProgressJustHeart = false;
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
        if (loseOrWin == 0)
            loseScreen.SetActive(true);
        else
            winningScreen.SetActive(true);
    }
    public void LoseHeart()
    {
        Hearts[heartNum - 1].sprite = emptySprite;
        heartNum++;
        if (heartNum > 3)
        {
            stopTimer = true;
            loseScreen.SetActive(true);

        }
    }
    public void Winning()
    {
        winningScreen.SetActive(true);
    }
}
