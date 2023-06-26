using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    public Ball ball;
    public Text scorePlayer;
    public Text scoreComputer;
    private int playerScore;
    private int computerScore;

    public void PlayerScore()
    {
        playerScore++;
        scorePlayer.text = playerScore.ToString();
        playerPaddle.ResetPosition();
        this.ball.ResetPosition();
        
    }

    public void ComputerScore()
    {
        computerScore++;
        scoreComputer.text = computerScore.ToString();
        computerPaddle.ResetPosition();
        this.ball.ResetPosition();
    }
    
}
