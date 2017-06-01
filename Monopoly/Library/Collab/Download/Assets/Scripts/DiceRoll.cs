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
        doubles = false;
        Random.InitState(System.Environment.TickCount);
        int roll1 = Random.Range(1, 7);
        int roll2 = Random.Range(1, 7);
        if (roll1 == roll2) doubles = true;
        roll = roll1 + roll2;
        return roll;
    }
	public int getDiceRoll() {
        return roll;
    }
    public bool getDoubles() {
        return doubles;
    }
}
