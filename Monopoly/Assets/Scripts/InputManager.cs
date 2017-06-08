using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 /* TODO:
  * - make escape key show menu with
  *     - a link to the rules
  *     - an option to exit to desktop
  * - finish dropdown for bidding
  */
public class InputManager : MonoBehaviour { 
    GameController g; // gamecontroller script

    GameObject moneyC; //money 
    GameObject playerT; // active player
    GameObject biddingPrice;
    GameObject biddingPlayer;
    GameObject biddingOk;

    bool bidClick = false;
    int salePrice;
    
    // Use this for initialization
    void Start () {
        g =  GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        moneyC = GameObject.Find("Money"); // initalization
        playerT = GameObject.Find("PlayersTurn");
        biddingPrice = GameObject.Find("Price");
        biddingPlayer = GameObject.Find("PlayerSelector");
        biddingOk = GameObject.Find("BiddingChoose");
    }

    void Update() {
		if(g.getCurrPlayer()){
	        moneyC.GetComponent<Text>().text = "$:" + g.getCurrPlayer().getMoney().ToString(); // update player's money each frame
	        playerT.GetComponent<Text>().text = g.getCurrPlayer().name; // update playername each frame
		}
	}

    public void rollDice() {
        g.move();//tell gamecontroller to move the player
        
    }
    public void payRent() {
        g.payRent(12); // tell the gamecontroller to pay the rent from the player to the other player
        
    }
    public void endTurn() {
        g.nextTurn(); // tell the gamecontroller to end the turn and move on to the next player
        
    }
    
    public void bidClicker() {
        bidClick = true;
    }

    public string bidding (Tile sale, string[] playersNames) {
        string player;
        
        

        biddingPlayer.GetComponentInParent<Transform>().gameObject.SetActive(true);

        while (bidClick != true) { }
        player = biddingPlayer.GetComponentInChildren<Text>().text;
        salePrice = int.Parse(biddingPrice.GetComponentInChildren<Text>().text);

        biddingPlayer.GetComponentInParent<Transform>().gameObject.SetActive(false);
        return player;
    }
    public int bidPrice() {
        return salePrice;
    }
    
}
