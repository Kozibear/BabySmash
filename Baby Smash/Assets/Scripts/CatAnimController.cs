using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimController : MonoBehaviour {

    private bool isAwake;
    private Animator Anim;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        isAwake = GetComponentInParent<Cat>().isAwake;
        
        if (isAwake == true)
        {
            Anim.SetBool("isAwake", true);
        }
	}
}
