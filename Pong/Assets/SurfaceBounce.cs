using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceBounce : MonoBehaviour
{

    public float bounceStrength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if(ball != null) 
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal*this.bounceStrength);
        }
    }
}
