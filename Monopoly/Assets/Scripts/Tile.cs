using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Tile
 * Task: Hold values a tile card would have in real Monopoly game
 * Contributors: Viktor Korolyuk, Hongbo Wang
 */

public class Tile : MonoBehaviour {

  //Value for tile price
  public int originalPrice = 100;

  string tileType;
  //What type of tile is it?
  string propertyName;
  //What is it called?
  PlayerController owner;
  //Reference to instance of PlayerController which a Player is using.


  // Use this for initialization
  void Start() {
    propertyName = gameObject.name; //Set default name
  }

  /*
     * GET and SET functions are defnined here. This allows controll over variables when they are referenced.
	 * 
	 */


  public int Rent {
    get {
      return this.originalPrice;
    }
    set {
      originalPrice = value;
    }
  }

  public string PropertyName {
    get {
      return this.propertyName;
    }
    set {
      this.propertyName = value;
    }
  }

  public PlayerController Owner {
    get {
      return this.owner;
    }
    set {
      owner = value;
    }
  }

  public string TileType {
    get {
      return this.tileType;
    }
    set {
      tileType = value;
    }
  }
}
