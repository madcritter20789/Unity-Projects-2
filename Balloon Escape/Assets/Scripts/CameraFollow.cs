using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {   
        //It find gameobject with tag "Player" and assign it to player variable.
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // It asssigns position of camera
        tempPos = transform.position;
        tempPos.x = player.position.x;

        // It sets minimum x coordinate of camera.
        if (tempPos.x < minX)
            tempPos.x = minX;

        // It sets maximum x coordinate of camera.
        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}
