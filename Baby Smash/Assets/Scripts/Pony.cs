using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pony : MonoBehaviour {

    private Rigidbody2D rb;
    private bool isJumped;
    public int h;
    public int v;
    public float moveTimeVal = 2;

    public float speed;
    private Vector3 forceDirection;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        h = Random.Range(-1, 2);
        v = Random.Range(-1, 2);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        
        transform.Translate(new Vector3(h, v, 0) * speed * Time.fixedDeltaTime);
        if (moveTimeVal <= 0.1)
        {
            
            h = Random.Range(-1, 2);
            v = Random.Range(-1, 2);
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
}
