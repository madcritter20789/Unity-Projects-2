using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        //If gameobject collide with gameobject with tag "Player" than it will move to next scene if build index is less than 3 otherwise quit the application.
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex < 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
