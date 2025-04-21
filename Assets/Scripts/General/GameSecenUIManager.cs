using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSecenUIManager : MonoBehaviour
{
    public RTLTextMeshPro playerName;
    public SpriteRenderer playerSprite;
    public List<Sprite> spriteGender = new List<Sprite>();
    public TMP_Text playerTag;
    public bool itExitButton = false;

    public GameObject muteIcon;

    public static GameSecenUIManager Instance { get; private set; }
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

    }

    // Start is called before the first frame update
    void Start()
    {
        playerName.text = PlayerData.Instance.playerName;
        playerSprite.sprite = spriteGender[PlayerData.Instance.playerGender];
        UpdatePlayerTag();
    }

    public void UpdatePlayerTag()
    {
        playerTag.text = PlayerPrefs.GetString("PlayerTag");

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
    public void Reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

        //sound
        SoundManager.PlaySound(SoundType.Buttons);
    }
    public void Exit()
    {
        Time.timeScale = 1;

        if (GameManager.Instance != null)
            GameManager.Instance.itExitButton = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
        else
            SceneManager.LoadScene(1);

        //sound
        SoundManager.PlaySound(SoundType.Buttons);
    }
    public void ToggelMute()
    {

        AudioSource[] audioSource = FindObjectsOfType<AudioSource>();
        foreach (AudioSource _audioSource in audioSource)
        {
            _audioSource.mute = !_audioSource.mute;
        }

        if (SoundManager.instance.audioSource.mute)
        {
            muteIcon.SetActive(true);
        }
        else
        {
            muteIcon.SetActive(false);
        }
    }
}
