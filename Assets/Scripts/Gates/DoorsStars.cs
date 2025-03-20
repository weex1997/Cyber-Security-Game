using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorsStars : MonoBehaviour
{
    public List<GameObject> starsObject = new List<GameObject>();
    public Sprite fillStar;
    int starsNum;
    int totalStars = 0;
    int currentStage;
    // Start is called before the first frame update
    void Start()
    {
        //get current player stage
        if (PlayerPrefs.HasKey("PlayerStage1"))
        {
            if (PlayerPrefs.HasKey("PlayerStage2"))
            {
                if (PlayerPrefs.HasKey("PlayerStage3"))
                {
                    currentStage = 3;
                }
                else
                    currentStage = 2;
            }
            else
                currentStage = 1;
        }
        else
            currentStage = 0;

        //loop for the stars
        //get all door with thier stars
        for (int i = 0; i < currentStage; i++)
        {
            starsObject[i].SetActive(true);
            starsNum = PlayerPrefs.GetInt("StarsForDoor" + (i + 1));
            totalStars += starsNum;
            //loop for stars image with curren door stars
            for (int j = 0; j < starsNum; j++)
            {
                starsObject[i].transform.GetChild(j).GetComponent<Image>().sprite = fillStar;
            }
            //save the number for all stars 
            if (i == currentStage - 1)
            {
                PlayerPrefs.SetInt("PlayerTotalStars", totalStars);
                PlayerData.Instance.SaveDataToTheServier();
            }
        }

    }


}
