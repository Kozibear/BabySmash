using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

    private Rigidbody2D rb;
    private bool isJumped;
    public int h;
    public float moveTimeVal = 2;

    public float speed;
    public float thrust;
    private Vector3 forceDirection;
    public bool isAwake=false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isAwake)
        {
            Move();
        }
        
    }

    private void Move()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        h = Random.Range(-1, 2);
        if (moveTimeVal <= 0.1)
        {
            rb.AddForce(new Vector2(h * thrust, thrust));
            h = Random.Range(-1, 2);
            moveTimeVal = 2;
        }
        else
        {
            moveTimeVal -= Time.fixedDeltaTime;
        }
    }

    private void BeSpringed(int springThrust)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, springThrust));
    }

    private void BeScreamed(float[] screamArray)
    {
        isAwake = true;
    }
}
