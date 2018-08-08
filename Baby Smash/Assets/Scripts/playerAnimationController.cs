using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour {

    public KeyCode leftKey;
    public KeyCode rightKey;
    private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        int key1 = 0;
        int key2 = 0;
        if (Input.GetKey (leftKey))
        {
            sr.flipX = true;
        }
        if (Input.GetKey(rightKey))
        {
            sr.flipX = false;
        }
	}
}
