using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{

	PlayerController[] PlayerGroup;
	Tile[] tiles;
	int playerTurn = 0;


	void init (){
		//Populate board
		if (GameObject.FindGameObjectWithTag ("BoardPopulate").GetComponent<BoardPopulate> ().init ()) {

			//get all players and tiles
			//and insert them into memory for later use

			//Sharing variable tempArr to minimize memory consumption.
			GameObject[] tempArr = GameObject.FindGameObjectsWithTag ("Tile"); //get the tiles in scene
			print(tempArr.Length);
			tiles = new Tile[tempArr.Length]; //define tiles array size
			int i = 0;
			foreach (GameObject e in tempArr) {
				tiles [i] = e.GetComponent<Tile> ();
				i++;
			}

			tempArr = GameObject.FindGameObjectsWithTag ("Player"); //get the players in scene
			PlayerGroup = new PlayerController[tempArr.Length]; //define player array size
			i = 0;
			foreach (GameObject e in tempArr) {
				PlayerGroup [i] = e.GetComponent<PlayerController> ();
				i++;
			}
			tempArr = null; //clearing memory after not used.

		}
	}

	float diceRoll (){
		//create a random dice roll.
		Random.seed = System.Environment.TickCount;
		return Random.Range (1, 7);
	}

	public void Move ()
	{
		float diceResult1 = diceRoll ();
		float diceResult2 = diceRoll ();
		//gives result from 1-6, does not account for doubles
		PlayerGroup [playerTurn].Move (
			(int)diceResult1,
			tiles[(PlayerGroup[playerTurn].getTileIndex() + (int)diceResult1) % tiles.Length].gameObject.transform.position); 
	}

	public void NextTurn (){
		//choose the nextplayer, if its the last player in the index, go back to player 1
		playerTurn++;
		playerTurn = playerTurn % PlayerGroup.Length;
	}

	void Start (){
		init ();
		Move ();
	}

	void Update ()
	{
		//Move ();
		if(Input.GetKey(KeyCode.A)){
			Move ();
		}
	}
}
