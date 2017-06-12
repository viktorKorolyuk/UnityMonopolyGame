using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
  int money = 0;
  int getOutOfJailFreeCards = 0;
  int TileIndex = 0;
  Vector3 pos;
  bool rolled;

  // Use this for initialization
  void Start() {
    money = 1500;
    pos = transform.position;
  }

  // Money actions
  public int getMoney() {
    return money;
  }

  //Check if player has enough money.
  public bool enouoghmoney(int sub) {
    if (money - sub > 0) {
      return true;
    } else {
      return false;
    }
  }

  //Deduct money from player
  public void payMoney(int pay) {
    money -= pay;
  }
  //Add money to player
  public void receiveMoney(int received) {
    money += received;
  }

  //Get new OOJ (out of jail) card
  public void getJailCard() {
    getOutOfJailFreeCards += 1;
  }

  //Use OOJ card
  public void playJailCard() {
    getOutOfJailFreeCards -= 1;
  }

  //How many OOJ cards doth the player have?
  public int getGetOutOfJailCards() {
    return getOutOfJailFreeCards;
  }

  // Movement
  public int getTileIndex() {
    return TileIndex;
  }

  //Move player
  public void Move(int movement, Vector3 newpos) {
    TileIndex += movement; //Abstractly move the player
    TileIndex = TileIndex % 40; // make sure the player loops when they reach EOA
    pos = newpos;
  }

  //Teleport the player to the correct position. Used for jail
  public void skipTo(int tile, Vector3 newpos) {
    TileIndex = tile;
    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newpos, 10);
    pos = newpos;
  }

  void Update() {
    pos.y = transform.position.y; //player should not rise

    //Move the player to the position using interpolation
    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, pos, Time.deltaTime);
  }

  public bool doneRoll {
    get {
      return this.rolled;
    }
    set {
      this.rolled = value;
    }
  }
}