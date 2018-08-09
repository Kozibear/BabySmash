using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public float scoreP1;
    public float scoreP2;
    public Text scoreP1Text;
    public Text scoreP2Text;

    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		GameSave.gameSave.Load ();

		scoreP1 = GameSave.gameSave.redPlayerScore;
		scoreP2 = GameSave.gameSave.bluePlayerScore;
	}
	
	// Update is called once per frame
	void Update () {
        scoreP1Text.text = "Player 1 Score: " + scoreP1.ToString();
        scoreP2Text.text = "Player 2 Score: " + scoreP2.ToString();
    }

}
