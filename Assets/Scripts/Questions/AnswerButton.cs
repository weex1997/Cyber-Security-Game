using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    bool isCorrect;
    [SerializeField] RTLTextMeshPro answerText;
    public Sprite defultSprite;
    [SerializeField] Sprite correctSprite;
    [SerializeField] Sprite wrongSprite;

    // To make it ask a new question after the first question
    [SerializeField] QuestionsSystem questionsSystem;

    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void OnClick()
    {
        if (isCorrect)
        {
            //sound
            SoundManager.PlaySound(SoundType.Correct);
            Debug.Log("CORRECT ANSWER");
            GetComponent<Image>().sprite = correctSprite;
            StartCoroutine(Wait());
            questionsSystem.StopAllButtons();
        }
        else
        {
            //sound
            SoundManager.PlaySound(SoundType.Wrong);
            Debug.Log("WRONG ANSWER");
            GetComponent<Image>().sprite = wrongSprite;
            questionsSystem.correctButton.GetComponent<Image>().sprite = correctSprite;
            StartCoroutine(Wait());
            questionsSystem.StopAllButtons();
            questionsSystem.successPercentage -= 100 / questionsSystem.totalQuestions;

        }
    }
    IEnumerator Wait()
    {
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(2);

        // Get the next question if there are more in the list
        if (questionsSystem.categoryQuestions.Count > 0 && questionsSystem.currentQuestionNum < questionsSystem.totalQuestions - 1)
        {
            // Generate a new question
            questionsSystem.StartTheQuestion();
            questionsSystem.currentQuestionNum++;
        }
        else
        {
            //must the question system script on panel gameobject to close it if the questions finshed
            questionsSystem.gameObject.SetActive(false);
            questionsSystem.questionActive = false;
            PlayerPrefs.SetFloat(questionsSystem.category, questionsSystem.successPercentage);
            Debug.Log(questionsSystem.category + " " + PlayerPrefs.GetFloat(questionsSystem.category));
            questionsSystem.finalDoor.CheckDoorsLock();
        }
    }
}
