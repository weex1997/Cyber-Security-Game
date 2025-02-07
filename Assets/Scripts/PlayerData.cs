using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string PlayerName;
    public int PlayerCoins;
    public int PlayerGender;
    public static PlayerData Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);

        PlayerName = PlayerPrefs.GetString("PlayerName");
        PlayerCoins = PlayerPrefs.GetInt("PlayerCoins");
        PlayerGender = PlayerPrefs.GetInt("PlayerGender");
    }

}
