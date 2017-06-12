using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCards {
  
    //TODO: After community card parser is finished, add more options to what can be chosen.  

    #pragma warning disable 0618  

    int[] chancecards;
    int[] communitycards;

	// Use this for initialization
	void Start () {

		//"[1]" represents the size of the array. This must be changed based on how many items are added.
		//Anything in "{" and "}" is what will be in the array. Make sure the added items are of STRING TYPE (usually shown as "  ").

		//Chance cards givea and take money from player. They sometimes put player in jail (GTJ).
		chancecards = new int[40] {10,-100,50,75,-75,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30};

		//Community cards can move position, and give out-of-jail cards (OOJ)
	}
	public int drawChanceCard(int random) {
        Random.seed = random;
    return Random.Range(-100, 200);
    }

}
