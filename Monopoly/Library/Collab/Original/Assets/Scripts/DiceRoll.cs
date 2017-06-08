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
        doubles = false;
        Random.InitState(System.Environment.TickCount);
        int roll1 = Random.Range(1, 7);
        int roll2 = Random.Range(1, 7);
        if (roll1 == roll2) doubles = true;
        roll = roll1 + roll2;
        return roll1;
    }
	public static int getDiceRoll() {
        return roll;
    }
	public static bool getDoubles() {
        return doubles;
    }
}
