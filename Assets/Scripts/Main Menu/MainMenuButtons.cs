using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void ContinueButton()
    {
        SceneManager.LoadScene(1);
        SoundManager.PlaySound(SoundType.Buttons);
    }
    public void GameInfoNext()
    {
        DialogueTriggers dialogueTriggers = FindObjectOfType<DialogueTriggers>();
        if (dialogueTriggers == null)
            SceneManager.LoadScene(1);

        SoundManager.PlaySound(SoundType.Buttons);

    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
        PlayerData.Instance.totalTime.Start();
        PlayerData.Instance.LoadLocal();

        SoundManager.PlaySound(SoundType.Buttons);

    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ServerErrorbutton()
    {
        PlayerData.Instance.Start();
    }

}
