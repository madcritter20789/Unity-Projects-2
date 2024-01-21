using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f; 
    [SerializeField] float jumpSpeed = 10f; 
    [SerializeField] float climbSpeed = 10f; 
    [SerializeField] Vector2 death = new Vector2 (5f, 5f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunPoint;
 
    Vector2 moveInput;
    Rigidbody2D myRB;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;

    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRB.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return;  }
        Run();
        flipSprite();
        ClimbLadder();
        Die();
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        Instantiate(bullet, gunPoint.position, transform.rotation); ;
    }
    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }
    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            // do stuff
            myRB.velocity += new Vector2(0f, jumpSpeed);
        }

    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRB.velocity.y);
        myRB.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRB.velocity.x) > Mathf.Epsilon;

        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void flipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRB.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRB.velocity.x), 1f);
        }
    }

    void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            myRB.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }
        Vector2 climbVelocity = new Vector2(myRB.velocity.x, moveInput.y*climbSpeed);
        myRB.velocity = climbVelocity;
        myRB.gravityScale = 0;

        bool playerHasVerticalSpeed = Mathf.Abs(myRB.velocity.y)>Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
    }
    void Die()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRB.velocity = death;
            FindObjectOfType<GameSession>().ProcessPlayerDeath(); 
        }
    }
}
