using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSecenUIManager : MonoBehaviour
{
    public TMP_Text playerName;
    public SpriteRenderer playerSprite;
    public List<Sprite> spriteGender = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        playerName.text = PlayerData.Instance.PlayerName;
        playerSprite.sprite = spriteGender[PlayerData.Instance.PlayerGender];
    }

    public void OpenWindow(GameObject Window)
    {
        if (Window.activeInHierarchy)
            Window.gameObject.SetActive(false);
        else
            Window.gameObject.SetActive(true);

    }
}
