using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] float reloadTime = 0.25f;
    [SerializeField] ParticleSystem crashEfect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Snow" && !hasCrashed)
        {
            hasCrashed = true;
            Debug.Log("Ouch!!!");
            FindObjectOfType<PlayerController>().DisableMovement();
            crashEfect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
