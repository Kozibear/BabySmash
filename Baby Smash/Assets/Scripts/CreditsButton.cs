using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour {

	public GameObject CreditsScreen;

	public Button credits;

	// Use this for initialization
	void Start () {
		credits.onClick.AddListener (credits1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void credits1 () {
		CreditsScreen.SetActive (true);
	}
}
