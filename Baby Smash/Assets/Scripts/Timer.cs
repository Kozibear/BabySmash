﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float sceneNumber;

	public bool nextScene;

	public float timeLeft;

	public Text timeLeftText;

	public GameObject TimesUpText;

	// Use this for initialization
	void Start () {

		nextScene = true;

		StartCoroutine(TimeLoop());
	}
	
	// Update is called once per frame
	void Update () {

		timeLeftText.text = "Time: " + timeLeft;

		if (timeLeft == 0) {

			TimesUpText.SetActive (true);

			if (sceneNumber == 1 && nextScene) {
				nextScene = false;

				StartCoroutine (OnToStage2());
			}

			if (sceneNumber == 2 && nextScene) {

				nextScene = false;

				StartCoroutine (OnToStage3());
			}

			if (sceneNumber == 3 && nextScene) {

				nextScene = false;

				StartCoroutine (ReturnToTitle());
			}
		}
	}

	private IEnumerator TimeLoop()
	{
		while (timeLeft > 0) {
			yield return new WaitForSeconds (1);
			timeLeft -= 1;
		}
	}

	private IEnumerator OnToStage2()
	{
		yield return new WaitForSeconds (3);

		SceneManager.LoadScene ("Stage2", LoadSceneMode.Single);
	}

	private IEnumerator OnToStage3()
	{
		yield return new WaitForSeconds (3);

		SceneManager.LoadScene ("Stage3", LoadSceneMode.Single);
	}

	private IEnumerator ReturnToTitle()
	{
		yield return new WaitForSeconds (6);

		SceneManager.LoadScene ("Title Screen", LoadSceneMode.Single);
	}
}
