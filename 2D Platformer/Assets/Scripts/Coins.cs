using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] public int valueG = 25;
    [SerializeField] public int valueS = 15;
    [SerializeField] public int valueB = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
     if(other.gameObject.tag == "Player")   
     {
        Destroy(gameObject);
     }
    }


}
