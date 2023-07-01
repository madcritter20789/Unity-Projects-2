using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    public float movementX,movementY;
    [SerializeField] float moveForce = 10f;
    public int score;
    [SerializeField] int coinValue = 10;
    Animator ballonAnim;
    private Rigidbody2D rb;
    public TMP_Text scoreText;
    [SerializeField] private AudioSource popSound;

    // Start is called before the first frame update
    void Start()
    {
        //It will get reference of component Animator.
        ballonAnim = GetComponent<Animator>();
        //It will get reference of component Rigidbody2D.
        rb = GetComponent<Rigidbody2D>();
        //It displays text on the screen 
        scoreText.text = "SCORE: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //It will make your player move in x coordinate using W,S or Up,Down arrow keys.
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        //It will make your player move in y coordinate using A,D or Left,Right arrow keys.
        movementY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(0f, movementY, 0f) * Time.deltaTime * moveForce;
        //It will display score on screen.
        scoreText.text = "SCORE: " + score.ToString();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //It will play pop sound and an animation when player collide with gamobject having tag "Traps". 
        if (other.gameObject.tag == "Traps")
        {  
            popSound.Play();
            ballonAnim.SetTrigger("Destroy");  
        }
        //It will add score if player collide with gameobject having tag "Coin".
        if (other.gameObject.tag == "Coin")
        {
            score += coinValue;
        }   
    }
    
}
