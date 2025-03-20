using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataPanel : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_InputField playerUserNameInput;
    public TMP_InputField playerAgeInput;

    string playerName;
    string playerUserName;
    string playerAge;
    public List<GameObject> Panels = new List<GameObject>();
    public GameObject nextButton;
    int nextPanel = 0;
    public int playerGender = 0;
    public GameObject messagesWindow;
    bool runOnce1 = false;
    bool runOnce2 = false;

    void Update()
    {
        if (PlayerData.Instance.loginSucsses && !runOnce1)
        {
            messagesWindow.SetActive(false);

            if (!PlayerPrefs.HasKey("PlayerName") && !PlayerPrefs.HasKey("PlayerGender"))
            {
                Panels[0].SetActive(true);
                nextButton.SetActive(true);
            }
            else
            {
                Panels[3].SetActive(true);
                nextButton.SetActive(false);
            }
            runOnce1 = true;

        }
        if (PlayerData.Instance.loginError && !runOnce2)
        {
            messagesWindow.SetActive(true);
            runOnce2 = true;
        }

    }
    public void NextButton()
    {
        if (nextPanel == 0)
        {
            if (playerNameInput.text != "")
            {
                playerName = playerNameInput.text;
                playerUserName = playerUserNameInput.text;
                playerAge = playerAgeInput.text;

                Panels[nextPanel].SetActive(false);
                nextPanel++;
                Panels[nextPanel].SetActive(true);
                Debug.Log("Player name is " + playerName);


                PlayerPrefs.SetString("PlayerName", playerName);
                PlayerPrefs.SetString("PlayerUserName", playerUserName);
                PlayerPrefs.SetString("PlayerAge", playerAge);

                PlayerData.Instance.AnalyticsAge(Convert.ToInt32(playerAge));

            }
            else
                Debug.Log("Error");
        }
        else if (nextPanel == 1)
        {
            Panels[nextPanel].SetActive(false);
            nextPanel++;
            Panels[nextPanel].SetActive(true);

            if (playerGender == 0)
            {
                Debug.Log("Player gender is Girl" + playerGender);
                PlayerPrefs.SetInt("PlayerGender", playerGender);
            }

            else
            {
                Debug.Log("Player gender is Boy" + playerGender);
                PlayerPrefs.SetInt("PlayerGender", playerGender);
            }

        }
        else if (nextPanel == 2)
        {
            Panels[nextPanel].SetActive(false);
            nextPanel++;
            Panels[nextPanel].SetActive(true);

        }
        if (nextPanel == 2)
        {

            nextButton.SetActive(false);
        }

        PlayerData.Instance.SaveDataToTheServier();

        SoundManager.PlaySound(SoundType.Buttons);
    }

}
