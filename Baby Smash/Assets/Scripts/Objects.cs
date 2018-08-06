using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

    

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
}
