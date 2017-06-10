using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name: GameController
 * Task: Control all actions which take place in the game.
 * 
 * Notes: Code was designed to be dynamic and adapt to different inputs. 
 * Design idea was scrapped during production and replaced with hard-coded values (Tiles, Luckey Cards)
 * Terminology:
 * Contributors: Viktor Korolyuk
 */

public class GameController : MonoBehaviour {

	PlayerController[] PlayerGroup;
	PlayerController currPlayer;
	Tile[] Tiles;
	int playerTurn = 0;

	void Start() {
		
	}

	void update() {
		
	}

	//Setup the much-needed variables for game functionality
	public void init() {
		//Get all players and tiles on board
		// and insert them into memory for later use.

		Tiles = GameObject.FindGameObjectWithTag("Scanner").GetComponent<TileScanner>().Tiles.ToArray();
		int i = 0; //Set an iterator for array index set.

		GameObject[] tempArr = GameObject.FindGameObjectsWithTag("Player"); //get the players in scene
		PlayerGroup = new PlayerController[tempArr.Length]; //define player array size
		i = 0; //Reset index iterator.

		//Iterate through all avaliable players.
		foreach (GameObject e in tempArr) {
			PlayerGroup[i] = e.GetComponent<PlayerController>();
			i++;
		}
		currPlayer = PlayerGroup[0];
		tempArr = null; //clearing memory after variable is not used
	}

	//Allow selected player to move
	public void move() {
		if (currPlayer.doneRoll == true)
			return;
		int diceResult1 = (int)DiceRoll.rollDice();

		print("diceResult: " + diceResult1 + ", tileIndex: " + currPlayer.getTileIndex() + ", loopTileIndex: " + (currPlayer.getTileIndex() + diceResult1) % Tiles.Length);

		Tiles[currPlayer.getTileIndex()].gameObject.GetComponent<MeshRenderer>().enabled = false; //Set old tile to be invisible
		currPlayer.Move(diceResult1, Tiles[(PlayerGroup[playerTurn].getTileIndex() + diceResult1) % Tiles.Length].gameObject.transform.position); 
		Tile currTile = Tiles[currPlayer.getTileIndex()];
		currTile.gameObject.GetComponent<MeshRenderer>().enabled = true;
		if (currTile.Owner != currPlayer)
			;
		if (DiceRoll.getDoubles()) {
			print("doubles get");
			move();
		} else {
			currPlayer.doneRoll = true;
		}

	}

	//Allow selected player to trade
	public void trade(PlayerController who, Tile property, int amount) {
		//TODO: fill in. I request David's time on this task.
	}

	//Deduct money from player
	public void payRent() {
		if (currPlayer.enouoghmoney(Tiles[currPlayer.getTileIndex()].rent) == true) { 
			currPlayer.payMoney(Tiles[currPlayer.getTileIndex()].Rent);
		} else {
			print("You Died! you're out!");
			Destroy(currPlayer.gameObject);
			//SceneManager.LoadScene (Application.LoadLevel);
		}
	}

	//Change selected player
	public void nextTurn() {
		//choose the nextplayer, if its the last player in the index, go back to player 1
		playerTurn++;
		playerTurn = playerTurn % PlayerGroup.Length;
		currPlayer = PlayerGroup[playerTurn];
		currPlayer.doneRoll = false;
	}

	public PlayerController[] getPlayers() {
		return PlayerGroup;
	}

	public Tile[] getTiles() {
		return Tiles;
	}

	public PlayerController getCurrPlayer() {
		if (currPlayer)
			return currPlayer;
		return null;
	}

}
