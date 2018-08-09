using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleDrop : MonoBehaviour {

    public AudioSource Bottle;



    // Use this for initialization
    void Start() {
        Bottle = GetComponent<AudioSource>();
        Invoke("SoundEnable", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Bottle.isPlaying)
        {
            Debug.Log(collision.collider.tag);
            if (collision.collider.tag == "Ground" || collision.collider.tag == "Objects" || collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
            {
                Debug.Log("playBottle");
                Bottle.Play();
               
            }
        }
        
    }

    private void SoundEnable()
    {
        Bottle.volume = 1;
    }
}
