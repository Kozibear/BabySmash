using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startButtonScript : MonoBehaviour {

	public Image blackBackground;

	public Color blackBackgroundColor;

	public bool darkenScreen;

	public Button startGame;

	// Use this for initialization
	void Start () {
		GameSave.gameSave.Load ();

		GameSave.gameSave.redPlayerScore = 0;
		GameSave.gameSave.redPlayerScore = 0;

		GameSave.gameSave.Save ();

		darkenScreen = false;

		startGame.onClick.AddListener (startTheGame);
	}
	
	// Update is called once per frame
	void Update () {

		if (darkenScreen) {
			blackBackground.gameObject.SetActive (true);
			blackBackground.color = blackBackgroundColor;
			blackBackgroundColor.a += 0.05f;
		}

		if (darkenScreen && blackBackgroundColor.a >= 1) {
				SceneManager.LoadScene ("BugFrienD's Scene", LoadSceneMode.Single);
		}

	}


	void startTheGame() {
		darkenScreen = true;
	}
}
