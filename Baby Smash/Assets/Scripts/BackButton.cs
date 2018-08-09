using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour {

	public GameObject CreditsScreen;

	public Button back;

	// Use this for initialization
	void Start () {
		back.onClick.AddListener (goBack);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void goBack () {
		CreditsScreen.SetActive (false);
	}
}
