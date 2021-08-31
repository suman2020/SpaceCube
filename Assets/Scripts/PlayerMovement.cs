using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalSpeed = 3.0f;
    public float jumpSpeed = 5.0f;
    public Rigidbody rb;
    private float HorizontalInput;
    private float distToGround;
    //BoxCollider collider;
    public bool jump_taken = false;
    private CountDownManager stm;

    private PlayerCollision collide;

    protected Joystick joystick;


    private void Start()
    {
        gameObject.SetActive(true);
        stm = GameObject.Find("Canvas").GetComponent<CountDownManager>();
        // collider = GetComponent<BoxCollider>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        collide = GameObject.Find("Player").GetComponent<PlayerCollision>();
        joystick = FindObjectOfType<Joystick>();
           
    }
    private void FixedUpdate()
    {   // no player movement after the player is dead
        if (collide.isDead)
        {
            return;
        }
        // the character moves only after the countdown is completed
      
        SpeedManager();
        if (stm.countDownCompleted == true)
        {
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * HorizontalInput * horizontalSpeed * Time.fixedDeltaTime;
        
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
    }
    private void Update()
    {
        // no player movement after the player is dead
        if (collide.isDead)
        {
            return;
        }

       

        if (stm.countDownCompleted == true)
        {
            rb.velocity = new Vector3(joystick.Horizontal * horizontalSpeed , rb.velocity.y, rb.velocity.z);
            HorizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerJump();
            }

                

          
        }
    }
    // player can't jump when it is on the air
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }

    private void SpeedManager()
    {
        float Position = rb.position.z;


        if (Position >= 5.0f && Position < 250.0f)
        {
            speed = 10.0f;
        }

        else if (Position >= 250.0f && Position < 350.0f)
        {
            speed = 12.0f;
        }

        else if (Position >= 350.0f && Position < 450.0f)
        {
            speed = 13.0f;
            jumpSpeed = 5.25f;
        }

        else if (Position >= 450.0f && Position < 600.0f)
        {
            speed = 14.0f;
        }

        else if (Position >= 600.0f && Position < 1000.0f)
        {
            speed = 16.0f;
            
        }

        else
        {
            speed = 18.0f;
        }
            

    }
    public void PlayerJump()
    {
        if (IsGrounded())
        {
            if (jump_taken == true)
            {
                jumpSpeed = 12.0f;
                Vector3 v = rb.velocity;
                v.y = jumpSpeed;
                rb.velocity = v;
                jump_taken = false;
               
            }
            else
            {
                jumpSpeed = 5.0f;
                Vector3 v = rb.velocity;
                v.y = jumpSpeed;
                rb.velocity = v;
            }
        }
    }

}