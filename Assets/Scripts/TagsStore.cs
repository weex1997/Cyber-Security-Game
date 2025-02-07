using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TagsStore : MonoBehaviour
{
    public TMP_Text coinsText;
    public List<Button> tags = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = PlayerPrefs.GetInt("PlayerCoins").ToString();
    }

    public void Select()
    {
        foreach (Button b in tags)
        {
            b.interactable = true;
        }
        GetComponent<Button>().interactable = false;
    }
    public void Buy()
    {

    }
}
