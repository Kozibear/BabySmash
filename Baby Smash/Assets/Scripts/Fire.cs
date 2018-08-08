﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public float fireThrust;
    public GameObject fireEmber;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Player1"|| collision.collider.tag == "Player2")
        {
            collision.collider.SendMessage("BeSpringed", fireThrust);
            Instantiate(fireEmber, transform.position, transform.rotation);
        }
        
    }
}