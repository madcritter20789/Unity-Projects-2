using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    public float restartDelay = 0.5f;
    //If player collides with gameobject with tag "Traps" it will invoke Restart method..
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Traps")
        {
            Invoke("Restart", restartDelay);
        }
    }

    //It will reload the current scene.
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
