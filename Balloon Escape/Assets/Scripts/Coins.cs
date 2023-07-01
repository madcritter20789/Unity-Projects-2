using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] public int valueGold = 25;

    void OnCollisionEnter2D(Collision2D other) 
    {
    // It will destroy the coin if it collides with player.
    if(other.gameObject.tag == "Player")   
    {
        Destroy(gameObject);
    }
    }


}
