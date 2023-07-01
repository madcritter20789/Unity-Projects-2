using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    //This function will provide the functionality to go to Main Menu for button.
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
