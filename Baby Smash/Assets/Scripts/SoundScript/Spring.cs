using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringFart : MonoBehaviour
{

    public AudioSource Springfart;



    // Use this for initialization
    void Start()
    {
        Springfart = GetComponent<AudioSource>();
        Invoke("SoundEnable", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Springfart.isPlaying)
        {
            Debug.Log(collision.collider.tag);
            if ( collision.collider.tag == "Objects" || collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
            {
                Debug.Log("playSpringfart");
                Springfart.Play();

            }
        }

    }

    private void SoundEnable()
    {
        Springfart.volume = 1;
    }
}

