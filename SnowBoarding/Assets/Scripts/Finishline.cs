using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishline : MonoBehaviour
{
    [SerializeField] float reloadTime = 1.0f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Finish!!!");
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", reloadTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
