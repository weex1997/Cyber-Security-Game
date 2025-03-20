using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTutorial : MonoBehaviour
{
    public GameObject[] tutorial;

    public GameObject TutorialObject;

    private GameObject robotNPC;
    bool runOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            robotNPC = FindObjectOfType<DialogueTriggers>().gameObject;
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("Caught NullReferenceException: " + ex.Message);
        }
    }
    void Update()
    {
        if (robotNPC == null && !runOnce)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Gates":
                    if (!PlayerPrefs.HasKey("WalkTutorial"))
                    {
                        TutorialObject.SetActive(true);
                        Time.timeScale = 0;

                        tutorial[0].SetActive(true);
                        PlayerPrefs.SetInt("WalkTutorial", 5);

                        SetAllCollidersInteract(false);
                    }
                    break;
                case "1":
                    if (!PlayerPrefs.HasKey("Tutorial1"))
                    {
                        TutorialObject.SetActive(true);
                        Time.timeScale = 0;

                        tutorial[2].SetActive(true);
                        PlayerPrefs.SetInt("Tutorial1", 5);

                        SetAllCollidersInteract(false);
                    }
                    break;
                case "2":
                    if (!PlayerPrefs.HasKey("Tutorial2"))
                    {
                        TutorialObject.SetActive(true);
                        Time.timeScale = 0;

                        tutorial[3].SetActive(true);
                        PlayerPrefs.SetInt("Tutorial2", 5);

                        SetAllCollidersInteract(false);
                    }
                    break;
                case "3":
                    if (!PlayerPrefs.HasKey("Tutorial3"))
                    {
                        TutorialObject.SetActive(true);
                        Time.timeScale = 0;

                        tutorial[4].SetActive(true);
                        PlayerPrefs.SetInt("Tutorial3", 5);

                        SetAllCollidersInteract(false);
                    }
                    break;
            }

            runOnce = true;
        }
    }
    public void CloseTutorial()
    {
        SetAllCollidersInteract(true);

        TutorialObject.SetActive(false);
        foreach (GameObject gameObject in tutorial)
            gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void TriggerTutorial()
    {
        if (!PlayerPrefs.HasKey("DoorTutorial"))
        {

            TutorialObject.SetActive(true);
            Time.timeScale = 0;

            tutorial[1].SetActive(true);
            PlayerPrefs.SetInt("DoorTutorial", 5);

            SetAllCollidersInteract(false);
        }

    }
    public void SetAllCollidersInteract(bool active)
    {
        BoxCollider2D[] clolliders = FindObjectsOfType<BoxCollider2D>();

        foreach (BoxCollider2D c in clolliders)
        {
            c.enabled = active;
        }
    }

}
