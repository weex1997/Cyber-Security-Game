using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosingWindow : MonoBehaviour
{
    public float timer = 30.0f;
    public float currenttime;
    public Image fillImage;
    bool stopTimer = false;
    public Button reloadButton;

    void Start()
    {
        currenttime = timer;

    }

    // Update is called once per frame
    void Update()
    {
        if (!stopTimer)
        {
            currenttime -= Time.deltaTime;
            fillImage.fillAmount = currenttime / timer;
            if (currenttime <= 0.0f)
            {
                fillImage.enabled = false;
                reloadButton.interactable = true;
                stopTimer = true;
            }
        }
    }
    public void Reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

        //sound
        SoundManager.PlaySound(SoundType.Buttons);
    }
}
