using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrail : MonoBehaviour {
	LineRenderer lr;
	int index = 0;
	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		lr.SetPosition (index, transform.position);
		index++;
		lr.positionCount++;
		lr.SetPosition (index, transform.position);

	}
}
