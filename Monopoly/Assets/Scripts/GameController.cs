using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	PlayerController[] PlayerGroup;
	Tile[] Tiles;
	int playerTurn = 0;


	void Start () {
		init ();
		move ();
	}

	void update () {

	}

	//Setup the much-needed variables for game functionality
	void init () {
		//Get all players and tiles on board
		// and insert them into memory for later use.

		//Sharing variable tempArr to minimize memory consumption.
		GameObject[] tempArr = GameObject.FindGameObjectsWithTag ("Tile"); //get the tiles in scene.
		Tiles = new Tile[tempArr.Length]; //define tiles array size.
		int i = 0; //Set an iterator for array index set.
		foreach (GameObject e in tempArr) {
			Tiles [i] = e.GetComponent<Tile> ();
			i++;
		}

		tempArr = GameObject.FindGameObjectsWithTag ("Player"); //get the players in scene
		PlayerGroup = new PlayerController[tempArr.Length]; //define player array size
		i = 0; //Reset index iterator.
		foreach (GameObject e in tempArr) {
			PlayerGroup [i] = e.GetComponent<PlayerController> ();
			i++;
		}
		tempArr = null; //clearing memory after not used.

	}
	//Allow selected player to move
	public void move () {
		float diceResult1 = DiceRoll.rollDice ();
		PlayerGroup [playerTurn].Move (
			1,
			Tiles[(PlayerGroup[playerTurn].getTileIndex() + 1) % Tiles.Length].gameObject.transform.position); 
	}

	//Allow selected player to trade
	public void trade(PlayerController who){
		
	}

	//Change selected player
	public void nextTurn () {
		//choose the nextplayer, if its the last player in the index, go back to player 1
		playerTurn++;
		playerTurn = playerTurn % PlayerGroup.Length;
	}

	/*
	 * Methods for InputManager to use.
	 */
	public PlayerController[] getPlayers(){
		return PlayerGroup;
	}

	public Tile[] getTiles(){
		return Tiles;
	}
	public PlayerController getCurrPlayer(){
		return PlayerGroup [playerTurn];
	}
}
