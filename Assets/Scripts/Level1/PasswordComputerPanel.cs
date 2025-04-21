using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordComputerPanel : MonoBehaviour
{
    public Image filled;
    public List<GameObject> Passwords = new List<GameObject>();
    public GameObject tip;
    int capetalLetter;
    int smallLetter;
    int number;
    int symbol;
    int childNum;
    float currentValue;

    //any move with drag object comes to this method to check password character
    public void CheckPasword()
    {
        capetalLetter = 0;
        smallLetter = 0;
        number = 0;
        symbol = 0;
        childNum = 0;
        currentValue = 0f;

        //loop for all password boxes input object
        //the loop checks if the box has children
        //if have checked the name of the child
        //increase the number of category

        foreach (GameObject character in Passwords)
        {
            if (character.transform.childCount != 0)
            {
                if (character.transform.GetChild(0).name == "CapetalLetter(Clone)")
                {
                    capetalLetter++;
                }
                if (character.transform.GetChild(0).name == "SmallLetter(Clone)")
                {
                    smallLetter++;
                }
                if (character.transform.GetChild(0).name == "Number(Clone)")
                {
                    number++;
                }
                if (character.transform.GetChild(0).name == "Symbol(Clone)")
                {
                    symbol++;
                }
                childNum++;
            }
        }

        //calculate the number of each category number
        //if the category has at least 1 character increase the value of the measure

        if (capetalLetter >= 1)
        {
            currentValue += 1.0f;
        }
        if (smallLetter >= 1)
        {
            currentValue += 1.0f;
        }
        if (number >= 1)
        {
            currentValue += 1.0f;
        }
        if (symbol >= 1)
        {
            currentValue += 1.0f;

        }

        //then divide the value by the number of categories
        filled.fillAmount = currentValue / 4;

    }

    //method for the create password button
    public void CreatePassword()
    {
        //check if the password boxes have the below rules
        if (capetalLetter >= 1 && smallLetter >= 1 && number >= 1 && symbol >= 1 && childNum == 6 && GameManager.Instance.heartNum > 0)
        {
            GameManager.Instance.checkEndTheGame();
        }
        else
        {
            GameManager.Instance.LoseHeart();
            StartCoroutine(OpenTip());
        }
    }
    IEnumerator OpenTip()
    {
        tip.SetActive(true);
        yield return new WaitForSeconds(5f);
        tip.SetActive(false);
    }
}
