using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSound;
    [SerializeField] int pointsToPickCoin = 10;

    bool wasCollected= false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsToPickCoin);
            AudioSource.PlayClipAtPoint(coinPickupSound, Camera.main.transform.position);
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
   
}
