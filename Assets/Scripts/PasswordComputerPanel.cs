using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordComputerPanel : MonoBehaviour
{
    public Image filled;
    public List<GameObject> Passwords = new List<GameObject>();
    int capetalLetter;
    int smallLetter;
    int number;
    int symbol;
    int childNum;
    float currentValue;

    public void checkPasword()
    {
        capetalLetter = 0;
        smallLetter = 0;
        number = 0;
        symbol = 0;
        childNum = 0;
        currentValue = 0f;

        foreach (GameObject passphrase in Passwords)
        {
            if (passphrase.transform.childCount != 0)
            {
                if (passphrase.transform.GetChild(0).name == "CapetalLetter(Clone)")
                {
                    capetalLetter++;
                }
                if (passphrase.transform.GetChild(0).name == "SmallLetter(Clone)")
                {
                    smallLetter++;
                }
                if (passphrase.transform.GetChild(0).name == "Number(Clone)")
                {
                    number++;
                }
                if (passphrase.transform.GetChild(0).name == "Symbol(Clone)")
                {
                    symbol++;
                }
                childNum++;
            }
        }
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
        filled.fillAmount = currentValue / 4;
    }

    public void createPassword()
    {

        if (capetalLetter >= 1 && smallLetter >= 1 && number >= 1 && symbol >= 1 && childNum == 6 && GameManager.Instance.heartNum < 3)
        {
            GameManager.Instance.Winning();
        }
        else
            GameManager.Instance.LoseHeart();
    }
}
