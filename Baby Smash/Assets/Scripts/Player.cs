using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode jumpKey;
    public KeyCode screamKey;

    public float moveSpeed;
    public float jumpThrust;
    public float stunnedTime;
    public float screamForce;
    public float playerNumber;
    public float screamTimeVal;

    public bool isJumping=true;
    public bool isStunned;
    private bool isScreamed = false;
    private float x;
    private float y;
    private float z;
    private float[] screamArray;
    private float stunnedTimeVal;


    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        stunnedTimeVal = stunnedTime;
	}

    private void Update()
    {
        if (Input.GetKeyDown(screamKey)&&!isScreamed)
        {
            isScreamed = true;
        }
        if (isScreamed)
        {
            if (screamTimeVal > 0.1)
            {
                screamTimeVal -= Time.deltaTime;
            }
            else if (screamTimeVal <= 0.1)
            {
                isScreamed = false;
                screamTimeVal = 3;
            }
        }
    }

    void FixedUpdate () {
        transform.eulerAngles = new Vector3(0, 0, 0);
        if (isStunned)
        {
            if (stunnedTimeVal >= 0.1)
            {
                stunnedTimeVal -= Time.fixedDeltaTime;
            }
            else if (stunnedTimeVal < 0.1)
            {
                isStunned = false;
                stunnedTimeVal = stunnedTime;
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

    private void BeSpringed(int springThrust)
    {
        rb.AddForce(new Vector2(0, springThrust));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (!isScreamed)
        //{
            if (Input.GetKeyDown(screamKey))
            {
            Stunned();
                if (collision.tag == "Objects" || collision.tag == "Object1" || collision.tag == "Object2"|| collision.tag == "Cat")
                {
                    x = transform.position.x;
                    y = transform.position.y;
                    z = transform.position.z;
                    screamArray = new float[5] { x, y, z, screamForce, playerNumber };
                    collision.SendMessage("BeScreamed", screamArray);
                }
                if (collision.tag == "Window")
                {
                    collision.SendMessage("BeScreamed",playerNumber);
                }
             }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJumping)
        {
            if (collision.collider.tag == "Player1"|| collision.collider.tag == "Player2")
            {
                collision.collider.SendMessage("Stunned");
            }
        }   
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground"|| collision.collider.tag == "Object1" || collision.collider.tag == "Object2" || collision.collider.tag == "Platform"||
            collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
        {
            isJumping = false;
        }
        if (collision.collider.tag == "Platform")
        {
            if (Input.GetKeyDown(downKey))
            {
                collision.collider.SendMessage("JumpDown", playerNumber);
            }
            
        }
        //if (Input.GetKeyUp(downKey))
        //{
        //    collision.collider.SendMessage("Resume");
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Object1" || collision.collider.tag == "Object2" || collision.collider.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
