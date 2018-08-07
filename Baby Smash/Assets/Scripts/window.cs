using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour {

    public Sprite brokenWindowSprite;
    public GameObject brokenGlass;
    private SpriteRenderer sr;


	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BeScreamed(float playerNumber)
    {
        sr.sprite = brokenWindowSprite;
        gameObject.tag = "BrokenWindow";
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
