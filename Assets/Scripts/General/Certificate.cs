using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using RTLTMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Certificate : MonoBehaviour
{
    public RTLTextMeshPro playerName;
    public RTLTextMeshPro playerDescription;
    public GameObject buttons;
    public GameObject certificate;
    public GameObject report;
    public GameObject splashScreen;

    public Camera cameraToCapture;

    // Start is called before the first frame update
    void Start()
    {

        //sound
        SoundManager.PlaySound(SoundType.Win, 0.5f);

        playerName.text = PlayerData.Instance.playerName;


        var ts1 = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("Level1Time"));
        var ts2 = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("Level2Time"));
        var ts3 = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("Level3Time"));
        var tsT = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("PlayerTotalTimeFloat"));

        playerDescription.text = "الإسم: " + PlayerData.Instance.playerName + "\n" +
 "المرحلة 1 - الوقت: " + string.Format("{0:0}:{1:00}", ts1.TotalMinutes, ts1.Seconds) + " عدد المحاولات: " + PlayerPrefs.GetInt("Level1Atempt") + "\n" +
 "المرحلة 2 - الوقت: " + string.Format("{0:0}:{1:00}", ts2.TotalMinutes, ts2.Seconds) + " عدد المحاولات: " + PlayerPrefs.GetInt("Level2Atempt") + "\n" +
 "المرحلة 3 - الوقت: " + string.Format("{0:0}:{1:00}", ts3.TotalMinutes, ts3.Seconds) + " عدد المحاولات: " + PlayerPrefs.GetInt("Level3Atempt") + "\n" +
 "الوقت الكلي للعب: " + string.Format("{0:0}:{1:00}", tsT.TotalMinutes, tsT.Seconds) + "\n" +
 "إجمالي عدد النجوم: " + PlayerData.Instance.playerStars + "\n" +
 "نسبة الإجابات الصحيحة: " + PlayerData.Instance.playerQPercent + "%";

        if (!PlayerPrefs.HasKey("StartTotalTimer"))
        {
            //stop total timer
            PlayerPrefs.SetInt("StartTotalTimer", 1);
            PlayerData.Instance.totalTime.Start();

            Analtics();
        }

        Invoke("ActiveTheButons", 3f);


    }
    void Analtics()
    {
        PlayerData.Instance.AnalyticsLevelAttempt("1", PlayerPrefs.GetInt("Level1Atempt"));
        PlayerData.Instance.AnalyticsLevelAttempt("2", PlayerPrefs.GetInt("Level2Atempt"));
        PlayerData.Instance.AnalyticsLevelAttempt("3", PlayerPrefs.GetInt("Level3Atempt"));

        PlayerData.Instance.AnalyticsTotlaTime(PlayerPrefs.GetFloat("PlayerTotalTimeFloat"));

        PlayerData.Instance.AnalyticsTotalStars(PlayerData.Instance.playerStars);

        PlayerData.Instance.AnalyticsQuizPercentage(PlayerData.Instance.playerQPercent);
    }
    void ActiveTheButons()
    {
        buttons.SetActive(true);
    }
    public void NextButton()
    {
        //sound
        SoundManager.PlaySound(SoundType.Buttons);

        if (certificate.activeSelf)
        {
            certificate.SetActive(false);
            report.SetActive(true);
        }
        else if (report.activeSelf)
        {
            report.SetActive(false);
            splashScreen.SetActive(true);
            Invoke("LoadMainMenu", 3f);
        }

    }
    public void DownloadImge()
    {
        //sound
        SoundManager.PlaySound(SoundType.Buttons);

        buttons.SetActive(false);
        StartCoroutine(CaptureScreenshot());
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);

    }

    IEnumerator CaptureScreenshot()
    {
        yield return new WaitForEndOfFrame(); // Wait for frame render

        // Create a texture with screen size
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // Convert texture to PNG
        byte[] bytes = screenshot.EncodeToPNG();
        string filename = $"Screenshot_{System.DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
        string filepath = Path.Combine(Application.persistentDataPath, filename);

        // Save to file
        File.WriteAllBytes(filepath, bytes);
        Debug.Log($"Screenshot saved: {filepath}");

        OpenScreenshotFolder();
        buttons.SetActive(true);

        // Clean up
        Destroy(screenshot);
    }
    void OpenScreenshotFolder()
    {
        string path = Application.persistentDataPath;
        Application.OpenURL("file://" + path);
    }
}
