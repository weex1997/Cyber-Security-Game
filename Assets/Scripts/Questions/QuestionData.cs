using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
public class QuestionData : ScriptableObject
{
    public string question;
    [Tooltip("Choose of this three category : PasswordCategory,ShieldCategory,CardCategory - must be the same")]
    public string category;
    [Tooltip("The correct answer should always be listed first, they are ranzomized later")]
    public string[] answers;
}
