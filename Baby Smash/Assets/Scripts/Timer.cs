using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float timeLeft;

	public Text timeLeftText;

	// Use this for initialization
	void Start () {

		StartCoroutine(TimeLoop());
	}
	
	// Update is called once per frame
	void Update () {

		timeLeftText.text = "Time: " + timeLeft;

		if (timeLeft == 0) {
			print ("end");
		}
	}

	private IEnumerator TimeLoop()
	{
		while (timeLeft > 0) {
			yield return new WaitForSeconds (1);
			timeLeft -= 1;
			print (timeLeft);
		}
	}
}
