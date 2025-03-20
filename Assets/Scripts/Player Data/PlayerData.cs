using System;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string playerName;
    public string playerUserName;
    public string playerAge;
    public int playerCoins;
    public int playerGender;
    public int playerStars;
    public int playerTotalTime;
    public int playerQPercent;
    public TotalTime totalTime;

    public bool loginSucsses = false;
    public bool loginError = false;

    public static PlayerData Instance
    { get; private set; }

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
        DontDestroyOnLoad(this);
    }
    public async void Start()
    {

        try
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services initialized successfully.");

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("Logged into the server successfully!");
            }

            AnalyticsService.Instance.StartDataCollection();

            loginSucsses = true;
        }
        catch (Exception e)
        {
            Debug.LogError("Login to the server failed: " + e.Message);
            loginSucsses = false;
            loginError = true;
        }
    }
    public void LoadLocal()
    {
        totalTime.SaveTime();
        playerName = PlayerPrefs.GetString("PlayerName");
        playerAge = PlayerPrefs.GetString("PlayerAge");
        playerUserName = PlayerPrefs.GetString("PlayerUserName");
        playerCoins = PlayerPrefs.GetInt("PlayerCoins");
        playerGender = PlayerPrefs.GetInt("PlayerGender");
        playerTotalTime = PlayerPrefs.GetInt("PlayerTotalTime");
        playerStars = PlayerPrefs.GetInt("PlayerTotalStars");
        playerQPercent = PlayerPrefs.GetInt("TotalSuccessPercentage");
    }

    async public void SaveDataToTheServier()
    {
        LoadLocal();

        var saveData = new Dictionary<string, object>();

        saveData["name"] = playerName;
        saveData["username"] = playerUserName;
        saveData["age"] = playerAge;
        saveData["playerCoins"] = playerCoins;

        if (playerGender == 0)
            saveData["playerGender"] = "Girl";
        else
            saveData["playerGender"] = "Boy";

        saveData["totalPlayTime"] = playerTotalTime;
        saveData["playerTotalStars"] = playerStars;
        saveData["totalSuccessPercentage"] = playerQPercent;

        await CloudSaveService.Instance.Data.Player.SaveAsync(saveData);
    }

    public void AnalyticsLevelTime(string level, float time)
    {
        CustomEvent customEvent = new CustomEvent("Level" + level + "TimeAnalysis")
        { {"TimeInt",(int)time} };
        AnalyticsService.Instance.RecordEvent(customEvent);
        Debug.Log("analyticsResult: " + customEvent);
    }
    public void AnalyticsLevelAttempt(string level, int attempt)
    {
        CustomEvent customEvent = new CustomEvent("Level" + level + "AttemptAnalysis")
        { {"Attempts",attempt} };
        AnalyticsService.Instance.RecordEvent(customEvent);
        Debug.Log("analyticsResult: " + customEvent);
    }
    public void AnalyticsAge(int age)
    {
        CustomEvent customEvent = new CustomEvent("AgeAnalysis")
        { { "Age",age} };
        AnalyticsService.Instance.RecordEvent(customEvent);
        Debug.Log("analyticsResult: " + customEvent);
    }
    public void AnalyticsTotlaTime(float time)
    {
        CustomEvent customEvent = new CustomEvent("TotlaTimeAnalysis")
        { { "TotalTimeInt",(int)time} };
        AnalyticsService.Instance.RecordEvent(customEvent);
        Debug.Log("analyticsResult: " + customEvent);
    }
    public void AnalyticsTotalStars(int stars)
    {
        CustomEvent customEvent = new CustomEvent("TotlaStarsAnalysis")
        { { "TotalStars",stars} };
        AnalyticsService.Instance.RecordEvent(customEvent);
        Debug.Log("analyticsResult: " + customEvent);
    }
    public void AnalyticsQuizPercentage(float percentage)
    {
        CustomEvent customEvent = new CustomEvent("QuizPercentageAnalysis")
        { { "QuizPercentage",percentage} };
        AnalyticsService.Instance.RecordEvent(customEvent);
        Debug.Log("analyticsResult: " + customEvent);
    }

}
