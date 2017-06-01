using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour {
    int roll;
    bool doubles;
	// Use this for initialization
	void Start () {
		
	}
	
    public int rollDice() {
        Random.InitState(System.Environment.TickCount);
        roll = Random.Range(1, 6);
        doubles = true;
        Random.InitState(System.Environment.TickCount);
        roll += Random.Range(1, 6);
        if (roll != Random.Range(1, 6)) doubles = false;
        return roll;
    }
	public int getDiceRoll() {
        return roll;
    }
    public bool getDoubles() {
        return doubles;
    }
}
