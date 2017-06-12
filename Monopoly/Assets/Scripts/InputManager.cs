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
using System;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {
  // GameController instance
  GameController g;

  GameObject escMenu;
  Text moneyC;
  Text playerT;
  // active player
  GameObject bidUi;
  GameObject doubles;

  // GameObject for memory save. Previous code was having MemoryOverflow errors. EDIT: Whilst this is true, the cause of the memory error is unknown, it might be unity itelf.
  GameObject reusable;

  int salePrice;
    

  // Use this for initialization
  void Start() {
    g = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    escMenu = GameObject.Find("EscMenu");
    moneyC = GameObject.Find("Money").GetComponent<Text>();
    playerT = GameObject.Find("PlayersTurn").GetComponent<Text>();
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
      moneyC.text = "$" + g.getCurrPlayer().getMoney().ToString(); 
      // Update playername each frame
      playerT.text = g.getCurrPlayer().name; 
    }
    // If ESC/esc/Escape key is pressed
    if (Input.GetKey(KeyCode.Escape)) {
      Time.timeScale = 0; // Pause the game Update() function
      escMenu.SetActive(true);
    }
  }

  //Restart the game
  public void restartGame(){
    SceneManager.LoadScene(Application.loadedLevel);
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

  // Tell GameController to buy property
  public void buyProperty() {
    g.buyProperty();
  }

  // This sets up first values for player
  public void startBidScreen() {
    Tile currentTile = g.getCurrTile();

    // Doth the tile belong to someone? If so, return. (We can't bid on pre-owned property, that's just silly)
    if (currentTile.Owner != null) return;

    // Make bidding ui visible (how else are they sipposed to interact with the buttons?)
    bidUi.SetActive(true);

    // Make Screen2 invisible.
    reusable = FindChildInParent.findChild(bidUi.transform, "Second Screen");
    reusable.SetActive(false);
    reusable = null;
  }

  public void bidCommence() {
    // Get base price
    GameObject price = GameObject.Find("PriceSelector");

    // Find the GameObject named "Text" in the price selector
    string rawBidText = FindChildInParent.findChild(price.transform, "Text").GetComponent<Text>().text;
    float result;
    float.TryParse(rawBidText, out result);
    print((result == 0) ? "we got a smart aleck over 'ere bill. I think its time we teach 'em a li'l' lesson." : null);
    result = (result == 0) ? g.getCurrPlayer().getMoney() * 2 : result;

    // Make Screen1 invisible.
    reusable = FindChildInParent.findChild(bidUi, "First Screen");
    reusable.SetActive(false);
    // Make Screen2 visible.
    reusable = FindChildInParent.findChild(bidUi, "Second Screen");
    reusable.SetActive(true);


    GameObject player1 = FindChildInParent.findChild(reusable.transform, "Player1");
    GameObject player2 = FindChildInParent.findChild(reusable.transform, "Player2");

    //Set Left-most text to be current player
    //Setting title for current player
    reusable = FindChildInParent.findChild(player1, "Player 1 Text");
    reusable.GetComponent<Text>().text = g.getCurrPlayer().name;

    //Setting current player bid price
    reusable = FindChildInParent.findChild(player1, "Player 1 bidText");
    reusable.GetComponent<Text>().text = "Bid: $" + result.ToString();

    //Set Right-most text to opposite player
    reusable = FindChildInParent.findChild(player2, "Player 2 Text");
    reusable.GetComponent<Text>().text = (g.getCurrPlayer().name == "Player1") ? "Player2" : "Player1";

    //Setting current player bid price
    reusable = FindChildInParent.findChild(player2, "Player 2 bidText");
    reusable.GetComponent<Text>().text = "Bid: $" + 0;
    reusable = null;
  }
}
