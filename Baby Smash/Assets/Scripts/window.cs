﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour {

    public Sprite brokenWindowSprite;
    public GameObject brokenGlass;
    private SpriteRenderer sr;
    public AudioSource windowAudio;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        windowAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BeScreamed(float playerNumber)
    {
        sr.sprite = brokenWindowSprite;
        gameObject.tag = "BrokenWindow";
        windowAudio.Play();
        Instantiate(brokenGlass, transform.position, transform.rotation);

        if (playerNumber == 1)
        {
            PlayerManager.Instance.scoreP1++;
        }
        else if(playerNumber == 2)
        {
            PlayerManager.Instance.scoreP2++;
        }
    }
}
