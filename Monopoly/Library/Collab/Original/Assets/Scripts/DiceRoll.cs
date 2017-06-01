using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll {
    static int roll;
	// Use this for initialization
	void Start () {
		
	}
	
    public static int rollDice() {
        Random.InitState(System.Environment.TickCount);
        roll = Random.Range(1, 6);
        Random.InitState(System.Environment.TickCount);
        roll += Random.Range(1, 6);
        return roll;
    }
	public int getDiceRoll() {
        return roll;
    }
}
