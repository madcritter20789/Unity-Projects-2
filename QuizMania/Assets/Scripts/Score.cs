using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int correctAnswers = 0;
    int questionSeen = 0;

    public int GetCorrectAnswer()
    {
        return correctAnswers;
    }
    public int GetQuestionSeen()
    {
        return questionSeen;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public void IncrementQuestionSeen()
    {
        questionSeen++;
    }
    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctAnswers/(float)questionSeen*100);
    }

}
