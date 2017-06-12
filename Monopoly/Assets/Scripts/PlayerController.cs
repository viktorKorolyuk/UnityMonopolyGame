using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
  int money = 1500;
  int getOutOfJailFreeCards = 0;
  int TileIndex = 0;
  Vector3 pos;
  bool rolled = false;
  bool paidMoney = false;
  
  // Use this for initialization
  void Start() {
    pos = transform.position;
  }

  public bool paidMoneyProp{
    get{ 
      return this.paidMoney;
    } set{
      this.paidMoney = value;
    }
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
    paidMoney = true;
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

  public void createStaticCopy(Tile tile){
    GameObject smallMe = Instantiate(gameObject);
    //Remove playerController from object

    Vector3 extents = tile.gameObject.GetComponent<Collider>().bounds.extents;
    Destroy(smallMe.GetComponent<PlayerController>());

    // Set the small version of player position to top-left corner of tile.
    float xPos = tile.gameObject.transform.position.x + extents.x;
    float zPos = tile.gameObject.transform.position.z + extents.z;

    Vector3 newPos = new Vector3(xPos,smallMe.transform.position.y,zPos);
    smallMe.transform.position = newPos;
  }
}