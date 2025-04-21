using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TagsStore : MonoBehaviour
{
    public TMP_Text playerCoinsText;
    public int playerCoins;
    [HideInInspector]
    public List<Button> tagsButtons = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        playerCoins = PlayerPrefs.GetInt("PlayerCoins");
        playerCoinsText.text = playerCoins.ToString();

        for (int i = 0; i < tagsButtons.Count; i++)
        {
            Debug.Log(i);
            TagData tagData = tagsButtons[i].GetComponent<TagData>();
            if (tagData.sold)
            {
                tagData.gameObject.GetComponent<Button>().enabled = false;
            }
        }
    }

    public void Select(Button ThisButton)
    {
        foreach (Button b in tagsButtons)
        {
            b.interactable = true;
        }
        ThisButton.GetComponent<Button>().interactable = false;
    }
    public void Buy()
    {

        foreach (Button b in tagsButtons)
        {
            if (b.interactable == false)
            {
                TagData tagData = b.GetComponent<TagData>();
                playerCoins = PlayerPrefs.GetInt("PlayerCoins");
                if (playerCoins >= tagData._tagPrice)
                {
                    PlayerPrefs.SetString(tagData.tagId, tagData._tagText);
                    tagData.tagPriceObject.SetActive(false);
                    PlayerPrefs.SetInt("PlayerCoins", playerCoins - tagData._tagPrice);
                    playerCoins = PlayerPrefs.GetInt("PlayerCoins");
                    playerCoinsText.text = playerCoins.ToString();
                    b.GetComponent<Button>().enabled = false;
                    PlayerPrefs.SetString("PlayerTag", tagData._tagText);
                    GameSecenUIManager.Instance.UpdatePlayerTag();

                    //sound
                    SoundManager.PlaySound(SoundType.Buy);
                }
                else
                    b.interactable = true;
            }
        }
    }
}
