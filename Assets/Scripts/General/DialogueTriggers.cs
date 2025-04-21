using System.Collections.Generic;
using RTLTMPro;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{
    public List<string> DialogueString = new List<string>();
    public GameObject DialogueBox;
    public RTLTextMeshPro DialogueText;
    public int clickNum = 0;
    bool start = false;
    public bool isThereCondtions = false;
    public bool itsDialogue;

    void Start()
    {
        if (!itsDialogue)
        {
            Time.timeScale = 0;
            DialogueBox.SetActive(true);
            DialogueText.text = DialogueString[clickNum];
            start = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            DialogueBox.SetActive(true);
            DialogueText.text = DialogueString[clickNum];
            start = true;
            //SetAllCollidersInteract(false);
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
                if (GameManager.Instance != null)
                    GameManager.Instance.dialogueCount++;

                //SetAllCollidersInteract(true);

                Destroy(gameObject);
            }

        }
    }

    // //method for active or deactivating collider in the game to not conflict with the dialog
    // public void SetAllCollidersInteract(bool active)
    // {
    //     BoxCollider2D[] clolliders = FindObjectsOfType<BoxCollider2D>();

    //     foreach (BoxCollider2D c in clolliders)
    //     {
    //         c.enabled = active;
    //     }
    // }
}
