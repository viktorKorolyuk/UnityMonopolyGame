using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
using System.IO;

public class GameController : MonoBehaviour {

  PlayerController[] PlayerGroup;
  PlayerController currPlayer;
  Tile[] Tiles;
  int playerTurn = 0;

  // Setup the much-needed variables for game functionality
  public void init() {
    
    // Get all players and tiles on board
    // and insert them into memory for later use.

    Tiles = GameObject.FindGameObjectWithTag("Scanner").GetComponent<TileScanner>().Tiles.ToArray();
    int i = 0; // Set an iterator for array index set.

    GameObject[] tempArr = GameObject.FindGameObjectsWithTag("Player"); // get the players in scene
    PlayerGroup = new PlayerController[tempArr.Length]; // define player array size
    i = 0; // Reset index iterator.

    // Iterate through all avaliable players.
    foreach (GameObject e in tempArr) {
      PlayerGroup[i] = e.GetComponent<PlayerController>();
      i++;
    }
    currPlayer = PlayerGroup[0];
    tempArr = null; // clearing memory after variable is not used
  }


  // Allow selected player to move
  public void move() {
    if (currPlayer.doneRoll == true) return;
    Tile currTileInstance = Tiles[currPlayer.getTileIndex()];
    int diceResult1 = (int)DiceRoll.rollDice();

    print("diceResult: " + diceResult1 + ", tileIndex: " + currPlayer.getTileIndex() + ", loopTileIndex: " + (currPlayer.getTileIndex() + diceResult1) % Tiles.Length);

    currTileInstance.gameObject.GetComponent<MeshRenderer>().enabled = false; // Set old tile to be invisible
    currPlayer.Move(diceResult1, Tiles[(PlayerGroup[playerTurn].getTileIndex() + diceResult1) % Tiles.Length].gameObject.transform.position);
    currTileInstance = Tiles[currPlayer.getTileIndex()];
    currTileInstance.gameObject.GetComponent<MeshRenderer>().enabled = true;

    if (DiceRoll.getDoubles()) {
      //Don't do any uneeded computation
      print("Player got doubles, rolling again");
      move();
    } else {
      // Do card effect on player
      tileEffect(currTileInstance);

      currPlayer.doneRoll = true;
    }
  }

  void tileEffect(Tile target) {
    // Pay player $200
    if (target.gameObject.name == "Go") currPlayer.payMoney(-200);
  }

  // Deduct money from player
  public void payRent() {
    // If the property is unowned or not bough by the player, pay rent
    if (getCurrTile().Owner == null || getCurrTile().Owner == currPlayer) return;
    if (verifyPayment(getCurrTile().Rent)) { 
      
      //Deduct money
      currPlayer.payMoney(getCurrTile().Rent);

      //Pay other player
      getCurrTile().Owner.payMoney(-getCurrTile().Rent);
    }
  }

  // Change selected player
  public void nextTurn() {
    if (currPlayer.paidMoneyProp = true) {
      // choose the nextplayer, if its the last player in the index, go back to player 1
      playerTurn++;
      playerTurn = playerTurn % PlayerGroup.Length;
      currPlayer = PlayerGroup[playerTurn];
      currPlayer.doneRoll = false;
      currPlayer.paidMoneyProp = false;
    } else {
      // Force the Player to pay rent
      payRent();
    }
  }

  public void buyProperty() {
    //If property is bought, don't buy it again
    if (getCurrTile().Owner != null) return;
    if (verifyPayment(getCurrTile().Rent)) currPlayer.payMoney(getCurrTile().Rent);

    // Set the tile owner to plyer owner
    getCurrTile().Owner = currPlayer;

    //Add player marker
    currPlayer.createStaticCopy(getCurrTile());
  }

  public bool verifyPayment(float price) {
    // Why double/triple/quadruple/{x} charge them?
    if (currPlayer.paidMoneyProp) return false;

    // Verify player hath enough money
    if (currPlayer.enouoghmoney(Tiles[currPlayer.getTileIndex()].Rent)) { 
      return true;

      // If they don't, show the ending screen
    } else {
      // Make winScreen visible
      GameObject winScreen = FindChildInParent.findChild(GameObject.Find("Canvas"), "GameStatus");
      winScreen.SetActive(true);

      // Current player is "dead", switch to next player,
      nextTurn();
      FindChildInParent.findChild(winScreen, "Winner Text").GetComponent<Text>().text = currPlayer.name;
      Destroy(currPlayer.gameObject);
      return false;
    }
  }

  public PlayerController[] getPlayers() {
    return PlayerGroup;
  }

  public Tile[] getTiles() {
    return Tiles;
  }

  public Tile getCurrTile() {
    return Tiles[currPlayer.getTileIndex()];
  }

  public PlayerController getCurrPlayer() {
    if (currPlayer) return currPlayer;
    return null;
  }

}
