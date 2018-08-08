using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
