using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCards {

	string[] chancecards = new string[10];
	string[] communitycards = new string[10];

	// Use this for initialization
	void Start () {
        //pull in chance cards via json importer
        // pull in community cards via json importer
	}
	public string drawChanceCard(int random) {
        Random.seed = random;
        return chancecards[(int)Random.Range(0,chancecards.Length)];
    }
    public string drawCommunityCard(int random) {
        Random.seed = random;
        return communitycards[(int)Random.Range(0, communitycards.Length)];
    }

}
