using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DiceRoll {

	/*
	 * Utility class for dice-roll handling ONLY.
	 */

    static int roll;
    static bool doubles;

    public static int rollDice() {
        doubles = false; // assume rolls are different 
        Random.InitState(System.Environment.TickCount);
        int roll1 = Random.Range(1, 7);
        int roll2 = Random.Range(1, 7);
        if (roll1 == roll2) doubles = true; // if both rolls are the same, it's doubles!
        roll = roll1 + roll2;
        return roll;
    }
	public static int getDiceRoll() { // asked for the diceroll, return it
        return roll;
    }
	public static bool getDoubles() { // if both dice returned the same value, this is true
        return doubles;
    }
}
