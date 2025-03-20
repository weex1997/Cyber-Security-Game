using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalTime : MonoBehaviour
{
    public float totalTime;
    public float customTime;

    public bool startTotalTimer = true;
    public bool startCustomTime = false;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    public void Start()
    {
        totalTime = PlayerPrefs.GetFloat("PlayerTotalTimeFloat");

        int totalTimeBool = PlayerPrefs.GetInt("StartTotalTimer");

        if (totalTimeBool == 0)
            startTotalTimer = true;
        else
            startTotalTimer = false;
    }

    void Update()
    {
        if (startTotalTimer)
            totalTime += Time.deltaTime;

        if (startCustomTime)
            customTime += Time.deltaTime;

    }
    public void SaveTime()
    {
        PlayerPrefs.SetFloat("PlayerTotalTimeFloat", totalTime);

        PlayerPrefs.SetInt("PlayerTotalTime", (int)totalTime);

    }
    void OnApplicationQuit()
    {
        SaveTime();
    }

}
