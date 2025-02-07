using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{
    public List<string> DialogueString = new List<string>();
    public GameObject DialogueBox;
    public TMP_Text DialogueText;
    public int clickNum = 0;
    bool start = false;
    public bool isThereCondtions = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            DialogueBox.SetActive(true);
            DialogueText.text = DialogueString[clickNum];
            start = true;
        }

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && start == true && !isThereCondtions)
        {
            clickNum++;

            if (clickNum < DialogueString.Count)
            {
                DialogueText.text = DialogueString[clickNum];
            }
            else
            {
                start = false;
                Time.timeScale = 1;
                GameManager.Instance.dialogueCount++;
                Destroy(gameObject);
            }

        }
    }
}
