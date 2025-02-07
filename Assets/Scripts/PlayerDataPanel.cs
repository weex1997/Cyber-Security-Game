using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataPanel : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    string playerName;
    public List<GameObject> Panels = new List<GameObject>();
    public GameObject nextButton;
    int nextPanel = 0;
    public int playerGender = 0;

    void Start()
    {
        if (PlayerPrefs.GetString("PlayerName") == "")
        {
            Panels[0].SetActive(true);
            nextButton.SetActive(true);
        }
        else
        {
            Panels[2].SetActive(true);
            nextButton.SetActive(false);
        }
    }
    public void NextButton()
    {
        if (nextPanel == 0)
        {
            if (playerNameInput.text != "")
            {
                playerName = playerNameInput.text;
                PlayerPrefs.SetString("PlayerName", playerName);

                Panels[nextPanel].SetActive(false);
                nextPanel++;
                Panels[nextPanel].SetActive(true);
                Debug.Log("Player name is " + playerName);
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
        if (nextPanel == 2)
        {

            nextButton.SetActive(false);
        }





    }

}
