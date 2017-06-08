using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	PlayerController[] PlayerGroup;
	PlayerController currPlayer;
	Tile[] Tiles;
	int playerTurn = 0;


	void Start () {
		
	}

	void update () {
		
	}

	//Setup the much-needed variables for game functionality
	public void init () {
		//Get all players and tiles on board
		// and insert them into memory for later use.


		Tiles = GameObject.FindGameObjectWithTag("Scanner").GetComponent<TileScanner>().Tiles.ToArray();
		int i = 0; //Set an iterator for array index set.

		GameObject[] tempArr = GameObject.FindGameObjectsWithTag ("Player"); //get the players in scene
		PlayerGroup = new PlayerController[tempArr.Length]; //define player array size
		i = 0; //Reset index iterator.
		foreach (GameObject e in tempArr) {
			PlayerGroup [i] = e.GetComponent<PlayerController> ();
			i++;
		}
		currPlayer = PlayerGroup [0];
		tempArr = null; //clearing memory after variable is not used
	}

	//Allow selected player to move
	public void move () {
		
		int diceResult1 = (int)DiceRoll.rollDice ();
		print ("Dice result: " + diceResult1 + ". currTileIndex: " + currPlayer.getTileIndex() + ". currTileIndex + diceResult: " + 
			(currPlayer.getTileIndex() + diceResult1) % Tiles.Length);
		print (Tiles [(currPlayer.getTileIndex () + diceResult1) % Tiles.Length].gameObject.name);
		currPlayer.Move (diceResult1, Tiles[(PlayerGroup[playerTurn].getTileIndex() + diceResult1) % Tiles.Length].gameObject.transform.position); 
	}

	//Allow selected player to trade
	public void trade(PlayerController who){
		
	}

	//Deduct money from player
	public void payRent(int amount){
		currPlayer.payMoney (amount);
	}

	//Change selected player
	public void nextTurn () {
		//choose the nextplayer, if its the last player in the index, go back to player 1
		playerTurn++;
		playerTurn = playerTurn % PlayerGroup.Length;
		currPlayer = PlayerGroup [playerTurn];
	}
		
	public PlayerController[] getPlayers(){
		return PlayerGroup;
	}

	public Tile[] getTiles(){
		return Tiles;
	}
	public PlayerController getCurrPlayer(){
		if (currPlayer)
			return currPlayer;
		return null;
	}

}
