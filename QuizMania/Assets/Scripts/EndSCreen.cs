using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSCreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    Score scoreManage;

    // Start is called before the first frame update
    void Awake()
    {
        scoreManage = FindObjectOfType<Score>();
    }

    public void ShowFinalScore()
    {
        finalScore.text = "Congratulations!\nYou got a score of "+ scoreManage.CalculateScore()+"%";    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
