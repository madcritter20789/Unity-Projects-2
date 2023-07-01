using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReduceSize : MonoBehaviour
{
    public float sizeMultiplier = 0.8f;
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //If your gameobject collides with gameobject having tag "Player" than it will run PickUp function.
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    //This function makes you player smaller.
    void PickUp(Collider2D player)
    {
        player.transform.localScale *= sizeMultiplier;
        Destroy(gameObject);
    }
}
