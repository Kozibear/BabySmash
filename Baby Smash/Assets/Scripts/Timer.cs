using System.Collections;
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

	public GameObject redWinsText;
	public GameObject blueWinsText;
	public GameObject tieText;

	public GameObject playerManager;

	// Use this for initialization
	void Start () {

		GameSave.gameSave.Load ();

		nextScene = true;

		StartCoroutine(TimeLoop());
	}
	
	// Update is called once per frame
	void Update () {

		timeLeftText.text = "Time: " + timeLeft;

		if (timeLeft == 0) {

			GameSave.gameSave.redPlayerScore = playerManager.GetComponent<PlayerManager> ().scoreP1;
			GameSave.gameSave.bluePlayerScore = playerManager.GetComponent<PlayerManager> ().scoreP2;

			GameSave.gameSave.Save ();

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

				if (GameSave.gameSave.redPlayerScore > GameSave.gameSave.bluePlayerScore) {
					redWinsText.SetActive (true);
				}

				if (GameSave.gameSave.redPlayerScore < GameSave.gameSave.bluePlayerScore) {
					blueWinsText.SetActive (true);
				}

				if (GameSave.gameSave.redPlayerScore == GameSave.gameSave.bluePlayerScore) {
					tieText.SetActive (true);
				}
					
				TimesUpText.SetActive (true);
				
				nextScene = false;

				StartCoroutine (ReturnToTitle());
			}
		}

		if (Input.GetKeyDown (KeyCode.U)) {
			
			GameSave.gameSave.redPlayerScore = 0;
			GameSave.gameSave.bluePlayerScore = 0;

			GameSave.gameSave.Save ();

			playerManager.GetComponent<PlayerManager> ().scoreP1 = GameSave.gameSave.redPlayerScore;
			playerManager.GetComponent<PlayerManager> ().scoreP2 = GameSave.gameSave.bluePlayerScore;

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

		SceneManager.LoadScene ("Stage3 Copy", LoadSceneMode.Single);
	}

	private IEnumerator ReturnToTitle()
	{
		yield return new WaitForSeconds (6);

		SceneManager.LoadScene ("Title Screen", LoadSceneMode.Single);
	}
}
