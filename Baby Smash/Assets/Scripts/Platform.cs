using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private PlatformEffector2D pe2d;
    private float disableTimeValP1=0.5f;
    public bool isDisabledP1=false;
    private float disableTimeValP2 = 0.5f;
    public bool isDisabledP2 = false;

    // Use this for initialization
    void Start () {
        pe2d = GetComponent<PlatformEffector2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDisabledP1)
        {
            if (disableTimeValP1 >= 0)
            {
                disableTimeValP1 -= Time.deltaTime;
            }
            else if (disableTimeValP1 <= 0)
            {
                isDisabledP1 = false;
                disableTimeValP1 = 0.5f;
                pe2d.colliderMask = 1 << 8|1<<0|1<<9;
            }
        }
        if (isDisabledP2)
        {
            if (disableTimeValP2 >= 0)
            {
                disableTimeValP2 -= Time.deltaTime;
            }
            else if (disableTimeValP2 <= 0)
            {
                isDisabledP2 = false;
                disableTimeValP2 = 0.5f;
                pe2d.colliderMask= 1 << 8 | 1 << 0 | 1 << 9;
            }
        }
    }

    private void JumpDown(float playerNumber)
    {
        if (playerNumber == 1)
        {
            pe2d.colliderMask = ~(1 <<8);
            isDisabledP1 = true;
        }
        if (playerNumber == 2)
        {
            pe2d.colliderMask = ~(1 << 9);
            isDisabledP2 = true;
        }

    }

    //private void Resume()
    //{
    //    print("Resume");
    //    pe2d.colliderMask += 8;
    //}
}
