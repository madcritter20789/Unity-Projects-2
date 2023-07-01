using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    //This function provide the functionality to go to next level to the button.
    public void LoadScene()
   {
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
}
