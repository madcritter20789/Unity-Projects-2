using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticle;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            dustParticle.Play();
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            dustParticle.Stop();
        }

    }
}
