using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleAISmart : MonoBehaviour {
	public float speed = 10f;
	public LayerMask bounceLayer;
	GameObject ball_gm;
	Transform ball;
	Collider2D col;
	Collider2D ballCol;
	float extents, bextents;
	float lastX, lastY, slope, yint,xsped;

	void Start(){
		ball_gm = GameObject.FindGameObjectWithTag ("Ball");
		col = GetComponent<Collider2D> ();
		ballCol = ball_gm.GetComponent<Collider2D> ();

		ball = ball_gm.transform;

		extents = col.bounds.extents.y;
		bextents = ballCol.bounds.extents.y;

		lastX = ball.position.x;
		lastY = ball.position.y;
	}
	void Update () {

		Vector3 tr = transform.position;
		float ballPosY = ball.position.y;
		float paddleMaxY = tr.y + extents;
		float paddleMinY = tr.y - extents;

		//Visualize the area where the ball can hit
		drawBorders(tr, paddleMaxY, paddleMinY);


		/*
		 * 									Calculations of AI start
		 * 								   --------------------------
		 */

		//We need to find the location where the ball will hit based on its linear trajectory
		 
		if (ball.position.x == lastX)
			return; //to ensure no NAN values exist when calculating slope

		xsped = ball.position.x - lastX; //delta x
		slope = (ball.position.y - lastY)/ xsped; //delta y divided by delta x
		yint = yintCalc(ball.position.y, slope, ball.position.x); //get y-intercept of tracectory to properly graph

		Vector3 ballHit = linearEquation (tr.x, slope, yint);
		Debug.DrawRay(ball.position, ballHit - ball.position);

		willHit(ball.position, ballHit - ball.position);

		lastX = ball.position.x;
		lastY = ball.position.y;
	}
	float yintCalc(float y, float m, float x){
		return y - m * x;
	}
	void drawBorders(Vector3 tr, float pmxY, float pmnY){
		//Draw top extents of paddle
		Vector3 ss = tr;
		ss.y = pmxY;
		Vector3 st = ss;
		st.x = 0;
		Debug.DrawLine (ss, st);

		//Draw bottom extents of paddle
		ss.y = pmnY;
		st.y = pmnY;
		Debug.DrawLine (ss, st);
	}

	float isNegative(float num){
		return (Mathf.Abs (num) == num) ? 1 : -1;
	}

	Vector3 linearEquation(float x, float m, float b){
		return new Vector3 (x, x * m + b, 0);
	}
	void willHit(Vector3 start, Vector3 ray){
		RaycastHit2D hit = Physics2D.Raycast (start, ray, Mathf.Infinity, bounceLayer);
		if (hit.collider != null) {
			//print (hit.collider.gameObject.tag);

			if (hit.collider.gameObject.tag == "MainCamera") {
				
				//Vector3 ballHit = linearEquation (transform.position.x, -slope, yintCalc(hit.point.y, -slope, hit.point.x)); //same euation but flipped slope
				Vector3 trajHit = new Vector3 (hit.point.x, hit.point.y, 0); //where the 'ball' will hit (gotten from raycast) and thus its new point
				Vector3 newRayDir = linearEquation(transform.position.x, -slope, yintCalc(trajHit.y, -slope, trajHit.x));

				RaycastHit2D newLine = Physics2D.Raycast(newRayDir, (newRayDir - trajHit), Mathf.Infinity, bounceLayer);
				//print (newLine.collider.gameObject.tag);
				Debug.DrawRay(trajHit, (newRayDir - trajHit), Color.blue);
		
				Vector3 mewLine = linearEquation(-100, slope, yintCalc(newLine.point.y, slope, newLine.point.x));
				Debug.DrawLine(newLine.point, mewLine, Color.red);
				Vector3 tr = transform.position;
				tr.y = newRayDir.y;
//				/willHit (newLine.point, mewLine - new Vector3(newLine.point.x, newLine.point.y, 0));
				transform.position = Vector3.Lerp(transform.position, tr, Time.deltaTime);
			}
		}
	}
}
