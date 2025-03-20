using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TagData : MonoBehaviour
{
    public int _tagPrice;
    public string _tagText;
    public TMP_Text tagPrice;
    public TMP_Text tagText;
    public GameObject tagPriceObject;
    public bool sold = false;
    public string tagId;
    void Awake()
    {
        if (PlayerPrefs.GetString(tagId) == _tagText)
            sold = true;
        else
            sold = false;
    }
    void Start()
    {

        if (sold)
            tagPriceObject.SetActive(false);

        tagPrice.text = _tagPrice.ToString();
        tagText.text = _tagText;
    }
}
