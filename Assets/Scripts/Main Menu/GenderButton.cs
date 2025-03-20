using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderButton : MonoBehaviour
{
    public List<GameObject> Genders = new List<GameObject>();
    public int Gender = 0;

    public PlayerDataPanel playerDataPanel;
    public void GenderButtonData()
    {
        foreach (GameObject b in Genders)
        {
            b.GetComponent<Image>().enabled = false;
            b.transform.GetChild(0).GetComponent<Image>().enabled = true;
            b.transform.GetChild(1).gameObject.SetActive(false);
        }
        gameObject.GetComponent<Image>().enabled = true;
        gameObject.transform.GetChild(0).GetComponent<Image>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        if (gameObject.name == "Girl")
            Gender = 0;
        else Gender = 1;
        playerDataPanel.playerGender = Gender;
    }
}
