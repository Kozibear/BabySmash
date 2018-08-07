using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    private float x;
    private float y;
    private float deltaX;
    private float deltaY;
    private float distance;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = 0.5f * (player1.transform.position.x + player2.transform.position.x);
        y = 0.5f * (player1.transform.position.y + player2.transform.position.y);
        transform.position = new Vector3(x, y, -10);
        deltaX = player1.transform.position.x - player2.transform.position.x;
        deltaY = player1.transform.position.y - player2.transform.position.y;
        distance = Mathf.Sqrt( deltaX*deltaX  + deltaY*deltaY );
        if (distance < 5)
        {
            GetComponent<Camera>().orthographicSize = 3.5f;
        }
        else if (distance >= 5)
        {
            GetComponent<Camera>().orthographicSize = distance * 0.7f;
        }
        
    }
}
