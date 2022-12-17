using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    bool grounded = true;
    bool dashing = false;
    int dashCount = 1;
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpForce = 200f;

    [Header("Camera")]
    Vector3 cameraPos; // camera position
    [SerializeField] Camera mainCamera;

    /*
    // Animations
    SpriteRenderer sprite;
    Animator anim;
    */
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        mainCamera = Camera.main;

        if (mainCamera) // if main camera exists
        {
            cameraPos = mainCamera.transform.position;
        }
        // Animations
        /*
        sprite = GetComponent<SpriteRenderer>(); // gets the player's sprite renderer component
        anim = GetComponent<Animator>(); // gets the player's animator component
        */
    }

    private void Update()
    {
        // Makes the camera follow the player
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, cameraPos.y, cameraPos.z);
        }

        grounded = isGrounded(); // checks if player is grounded
        
        /*
        anim.SetBool("Jump", !grounded);
        */

        // if player is grounded and jump key pressed
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(grounded)
            {
                //anim.SetBool("Jump", true);
                rb.AddForce(Vector2.up * jumpForce); // add jump force upward               
            }
        }

        if (dashCount < 0) 
        {
            dashCount = 0;
        }

        if (grounded) 
        {
            dashCount = 1;
        }

        if (!dashing && dashCount > 0) 
        {
            Dash();
        }
             
        float horizontal = Input.GetAxis("Horizontal");

        if(!dashing)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        /*
        // Set yVelocity in animator
        anim.SetFloat("yVelocity", rb.velocity.y);

        Animate();
        */
    }

    public IEnumerator CancelDash() 
    {
        yield return new WaitForSeconds(.25f);
        dashing = false;
    }

    void applyDash(Vector2 dir)
    {
        dashing = true;
        dashCount--;
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(dir * jumpForce);
        StartCoroutine(CancelDash());
    }

    void Dash()
    {
        // Dash up
        if (Input.GetKeyDown(KeyCode.I))
        {
            applyDash(Vector2.up);
        }

        // Dash right
        if (Input.GetKeyDown(KeyCode.L))
        {
            applyDash(Vector2.right);
        }

        // Dash down
        if (Input.GetKeyDown(KeyCode.K))
        {
            applyDash(Vector2.down);
        }

        // Dash left
        if (Input.GetKeyDown(KeyCode.J))
        {
            applyDash(Vector2.left);
        }
    }

    private bool isGrounded()
    {
        float extraHeight = 0.5f;
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D raycastHit = Physics2D.Raycast(coll.bounds.center, Vector2.down, coll.bounds.extents.y + extraHeight);
        return raycastHit.collider != null;
    }
    /*
    private void Animate()
    {
        if (rb.velocity.x < 0f) // flip the sprite to point to the right direction
        {
            sprite.flipX = true;
            anim.SetBool("Walk", true); // change animator parameter so that the character is walking
            anim.SetBool("Idle", false); // and stopds idling
        }
        else if (rb.velocity.x > 0f)
        {
            sprite.flipX = false;
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
        }
        else 
        {
            anim.SetBool("Walk", false); // change animator parameter so that the character stops walking
            anim.SetBool("Idle", true); // and starts idling
        }
    }
    */
}
