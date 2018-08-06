using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Object1")
        {
            PlayerManager.Instance.scoreP1++;
        }
        if (collision.tag == "Object2")
        {
            PlayerManager.Instance.scoreP2++;
        }
    }
}
