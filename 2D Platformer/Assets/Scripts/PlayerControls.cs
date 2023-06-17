using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerControls : MonoBehaviour
{
    public TMP_Text coinText;
    public int score = 0;   
    [SerializeField] public int valueG = 25;
    [SerializeField] public int valueS = 15;
    [SerializeField] public int valueB = 10;
    [SerializeField] float moveForce = 10f;
    [SerializeField] float jumpForce = 10f;
    float movementX,movementY;
    SpriteRenderer sr;
    Animator anim;
    Rigidbody2D rb;
    bool isJumping;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "SCORE : "+score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        AnimatePlayer();
        coinText.text = "SCORE : "+score.ToString();
    }

    void PlayerMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        //transform.position += new Vector3(movementX, 0f, 0f)*Time.deltaTime*moveForce;
        rb.velocity = new Vector2(movementX*moveForce, rb.velocity.y);
        
       // if(movementX>0)
      //  {Debug.Log(movementX);}
       // else if(movementX<0)
      //  {Debug.Log(movementX);}

        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
        
        //if(movementY>0)
        //{Debug.Log(movementY);}
       // if(movementY<0)
        //{Debug.Log(movementY);}
    }

    void AnimatePlayer()
    {
        if(movementX>0)
        {
            anim.SetBool("Run", true);
            sr.flipX = false;
        }
        else if (movementX<0)
        {
            anim.SetBool("Run", true);
            sr.flipX  = true;    
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        else if(other.gameObject.tag == "Gold")
        {
            score += valueG;
        }
        else if(other.gameObject.tag == "Silver")
        {
            score += valueS;
        }
        else if(other.gameObject.tag == "Bronze")
        {
            score += valueB;
        }

    }

}
