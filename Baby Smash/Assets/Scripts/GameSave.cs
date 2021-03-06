﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameSave : MonoBehaviour {

	public static GameSave gameSave;

	//for the red and blue players' individual score
	public float redPlayerScore;
	public float bluePlayerScore;

	void Awake () {
		//if the gameSave variable has not been assigned, we don't destroy it, and we make it reference this.
		if (gameSave == null) {
			DontDestroyOnLoad (gameObject);
			gameSave = this;
		} 
		//if control does exist, and this is not it, destroy it
		else if (gameSave != this) {
			Destroy (gameObject);
		}

	}

	void FixedUpdate() {
	}

	//write to a file:
	public void Save () {
		BinaryFormatter bf = new BinaryFormatter(); //we create a binary formatter
		FileStream file = File.Create(Application.persistentDataPath + "/playerSaveData.dat"); //the file in which we'll save the game data

		playerData data = new playerData ();

		data.redPlayerScore = redPlayerScore;
		data.bluePlayerScore = bluePlayerScore;

		bf.Serialize (file, data); //we serialize our data to the above file
		file.Close(); //at the end, we close the file
	}

	//read from a file:
	public void Load () {

		if (File.Exists (Application.persistentDataPath + "/playerSaveData.dat")) {

			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerSaveData.dat", FileMode.Open);
			playerData data = (playerData)bf.Deserialize (file);
			file.Close ();

			redPlayerScore = data.redPlayerScore;
			bluePlayerScore = data.bluePlayerScore;
		}
	}
}

[Serializable] //this tells unity that I can save the following to a file
class playerData {

	//for the red and blue players' individual score
	public float redPlayerScore;
	public float bluePlayerScore;

}
