﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode jumpKey;

    public float moveSpeed;
    public float jumpThrust;
    public float stunnedTimeVal;

    private bool isJumping;
    private bool isStunned;

    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if (isStunned)
        {
            if (stunnedTimeVal >= 0.1)
            {
                stunnedTimeVal -= Time.fixedDeltaTime;
            }
            else if (stunnedTimeVal < 0.1)
            {
                isStunned = false;
                stunnedTimeVal = 1;
            }  
        }
        else if (!isStunned)
        {
            
            Move();
            Jump();
        }
	}

    private void Move()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void Jump()
    {
        if (!isJumping)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                rb.AddForce(new Vector2(0, jumpThrust));
            }
        }    
    }

    private void Stunned()
    {
        isStunned = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJumping)
        {
            if (collision.collider.tag == "Player")
            {
                collision.collider.SendMessage("Stunned");
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isJumping = true;
        }
    }
}
