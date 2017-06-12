using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleMove : MonoBehaviour {

	public float speed = 10f;
	// Update is called once per frame
	void Update () {
		float y = 0;
		if (Input.GetAxis ("pongVertical") > 0) {
			y = speed;
		} else if(Input.GetAxis("pongVertical") < 0){
			y = -speed;
		}
		transform.position += new Vector3 (0, y * Time.deltaTime, 0);
	}
}
