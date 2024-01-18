using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndSCreen endSCreen;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endSCreen = FindObjectOfType<EndSCreen>();
    }
    // Start is called before the first frame update
    void Start()
    {
      

        quiz.gameObject.SetActive(true);
        endSCreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endSCreen.gameObject.SetActive(true);
            endSCreen.ShowFinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
