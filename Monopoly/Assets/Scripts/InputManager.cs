using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    GameController g;
	// Use this for initialization
	void Start () {
        g =  GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }
	
	public void endTurn() {
        g.NextTurn();
    }
}
