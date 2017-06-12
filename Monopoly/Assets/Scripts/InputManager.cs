using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.NetworkSystem;
using System.Diagnostics;

/* TODO:
  * - make escape key show menu with
  *     - a link to the rules
  * - finish dropdown for bidding
  * - Handle buy property (if not owned)
  */

public class InputManager : MonoBehaviour {
  // GameController instance
  GameController g;

  GameObject escMenu;
  GameObject moneyC;

  GameObject playerT;
  // active player
  GameObject bidUi;
  GameObject doubles;

  int salePrice;
    
  // Use this for initialization
  void Start() {
    g = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    escMenu = GameObject.Find("EscMenu");
    moneyC = GameObject.Find("Money");
    playerT = GameObject.Find("PlayersTurn");
    bidUi = GameObject.Find("Bidding");
    doubles = GameObject.Find("Doubles");


    // Set Escape menu to invisible.
    escMenu.SetActive(false);
    bidUi.SetActive(false);
  }

  void Update() {
    // If current player is not null (not recorded by GameController (g))
    if (g.getCurrPlayer()) { 

      // Update player's money each frame
      moneyC.GetComponent<Text>().text = "$" + g.getCurrPlayer().getMoney().ToString(); 

      // Update playername each frame
      playerT.GetComponent<Text>().text = g.getCurrPlayer().name; 
    }

    // If ESC/esc/Escape key is pressed
    if (Input.GetKey(KeyCode.Escape)) {
      Time.timeScale = 0; // Pause the game Update() function
      escMenu.SetActive(true);
    }

  }

  // If exit is triggered, quit the game
  public void exitApp() { 
    Application.Quit();
  }

  // When return to game is triggered, set the timescale back to 1, then close the escape menu
  public void backToGame() {
    Time.timeScale = 1;
    escMenu.SetActive(false);
  }

  public void rollDice() {
    // Tell gamecontroller to move the player
    g.move();
  }

  public void payRent() {
    // tell the gamecontroller to pay the rent from the player to the other player
    g.payRent(); 
  }

  public void endTurn() {
    // Tell the gamecontroller to end the turn and move on to the next player
    g.nextTurn(); 
  }

  // Tell GameCOntroller to buy property
  public void buyProperty() {
    
  }

  // This sets up first values for player
  public void startBidScreen() {
    Tile currentTile = g.currTile();

    // Make bidding ui visible (how else are they sipposed to interact with the buttons?)
    bidUi.SetActive(true);

    // Doth the tile belong to someone? If so, return. (We can't bid on pre-owned property, that's just silly)
    if (currentTile.Owner != null) return;

  }

  public void bidCommence() {
    // Get base price
    GameObject price = GameObject.Find("PriceSelector");

    string rawBidText = findChild(transform, "D").GetComponent<Text>().text;
    float result;
    float.TryParse(rawBidText, out result);
    if (result == float.NaN) result = g.currTile().Rent / 2;
  }

  // Allow for searching in parents for a child objects.
  GameObject findChild(Transform parent, string name) {
    //Loop through each transform element in the parent transform.
    foreach (Transform child in parent) {
      if (child.name == name) return child.gameObject; // "Hi, I would like to return this child.... what? Of course i'm serious! Stop looking at me like that!"

      // Search in sub-children (children in children)
      GameObject innerChild = findChild(child, name);
      if (innerChild != null) return innerChild;
    }
    return null;
  }

}
