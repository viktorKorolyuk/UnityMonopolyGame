using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour {
	public float xSpeed = 0.1f;
	public AudioClip wall, paddle;
	AudioSource AuS;
	float speed = 1f;
	int dir = 1;
	float x = 0;

	void Start(){
		AuS = GetComponent<AudioSource> ();
	}

	void Update () {
		x = dir * xSpeed * Time.deltaTime;
		transform.position += new Vector3 (x, 0, 0);
		transform.position += new Vector3 (0, speed * x, 0); //y = mx
	}
	void OnCollisionEnter2D(Collision2D obj){
		switch (obj.gameObject.tag) {
		case "MainCamera":
			speed *= -1;
			AuS.clip = wall;
			AuS.Play ();
			break;
		case "Paddle":
			dir *= -1;
			speed *= -1;
			AuS.clip = paddle;
			AuS.Play ();
			break;
		}
	}
}
