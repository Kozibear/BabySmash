using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

    private Vector3 forceDirection;

	// Use this for initialization
	void Start () {
        //rb.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player1"|| collision.collider.tag == "Object1")
        {
            gameObject.tag = "Object1";
        }
        else if (collision.collider.tag == "Player2"|| collision.collider.tag == "Object2")
        {
            gameObject.tag = "Object2";
        }
    }

    private void BeSpringed(int springThrust)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, springThrust));
    }

    private void BeScreamed(float[] screamArray)
    {
        Vector3 position =new Vector3 (screamArray[0], screamArray[1], screamArray[2]);
        forceDirection = transform.position - position;
        forceDirection= forceDirection.normalized;
        GetComponent<Rigidbody2D>().AddForce(forceDirection * screamArray[3]);
        if (screamArray[4] == 1)
        {
            gameObject.tag = "Object1";
        }
        if (screamArray[4] == 2)
        {
            gameObject.tag = "Object2";
        }
    }
}
