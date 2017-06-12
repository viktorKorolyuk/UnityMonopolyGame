using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleAI : MonoBehaviour {
	public float speed = 10f;
	GameObject ball_gm;
	Transform ball;
	Collider2D col;
	Collider2D ballCol;
	float extents, bextents;
	// Update is called once per frame
	void Start(){
		ball_gm = GameObject.FindGameObjectWithTag ("Ball");
		ball = ball_gm.transform;
		col = GetComponent<Collider2D> ();
		extents = col.bounds.extents.y;
		ballCol = ball_gm.GetComponent<Collider2D> ();
		bextents = ballCol.bounds.extents.y;
	}
	void Update () {
		Vector3 tr = transform.position;
		float ballPosY = ball.position.y;
		float paddleMaxY = tr.y + extents;
		float paddleMinY = tr.y - extents;

		//check if the ball lands somwhere on the paddle
		//thus its y values have to be in a certain range
		Vector3 ss = tr;
		ss.y = paddleMaxY;
		Vector3 st = ss;
		st.x = 0;
		Debug.DrawLine (ss, st);
		ss.y = paddleMinY;
		st.y = paddleMinY;
		Debug.DrawLine (ss, st);

		//if(paddleMinY <= ballPosY - bextents && ballPosY + bextents <= paddleMaxY){
			//the ball will hit the paddle at this time
			Debug.DrawLine(ball.position, tr, Color.green);
		//} else{

			float dir = ball.position.y - tr.y;
		//if (Mathf.Abs (dir) > bextents * 5) {
			float x = (Mathf.Abs (dir) == dir) ? 1f : -1f;
			transform.position += new Vector3 (0, x*speed * Time.deltaTime, 0);
		//}
		//}
	}
}
