using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	GameObject[] PlayerGroup; //Collection of players
	GameObject[] tiles;
	int playerTurn = 0;


	void init(){
		//get all avaliable players
		tiles = GameObject.FindGameObjectsWithTag ("Tile");
		PlayerGroup = GameObject.FindGameObjectsWithTag ("Player");
	}

	void diceRoll(){
		//create a random dice roll.
		Random.InitState ((int)(Random.Range(0, 1001) * Time.fixedTime));
		print (Random.Range (1, 7) + " --- " + Random.Range (1, 7));
	}

	public void Move(){
		// Called at the players turn

	}
	public void NextTurn(){
		//choose the nextplayer, if its the last player in the index, go back to player 1
		playerTurn = playerTurn % PlayerGroup.Length;
	}
}
