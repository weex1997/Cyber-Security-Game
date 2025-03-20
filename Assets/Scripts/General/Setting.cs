using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    string tag1;
    string tag2;
    string tag3;
    public List<string> tags = new List<string>();
    public void ChangeTags(GameObject window)
    {
        window.SetActive(true);
        tags.Clear();
        //must the name of virables as same as the tags id
        tag1 = PlayerPrefs.GetString("tag1");
        tag2 = PlayerPrefs.GetString("tag2");
        tag3 = PlayerPrefs.GetString("tag3");

        if (tag1 != "")
            tags.Add(tag1);
        if (tag2 != "")
            tags.Add(tag2);
        if (tag3 != "")
            tags.Add(tag3);
        //Clear the old options of the Dropdown menu
        dropdown.ClearOptions();

        //Add the options created in the List above
        dropdown.AddOptions(tags);

        //sound
        SoundManager.PlaySound(SoundType.Buttons);
    }

    public void ChooseTag()
    {
        if (PlayerPrefs.HasKey("PlayerTag"))
        {
            PlayerPrefs.SetString("PlayerTag", dropdown.options[dropdown.value].text);
            GameSecenUIManager.Instance.UpdatePlayerTag();

            //sound
            SoundManager.PlaySound(SoundType.Buttons);
        }
    }
    public void OpenWindow(GameObject Window)
    {
        if (Window.activeInHierarchy)
            Window.gameObject.SetActive(false);
        else
            Window.gameObject.SetActive(true);

        //sound
        SoundManager.PlaySound(SoundType.Buttons);
    }

}
