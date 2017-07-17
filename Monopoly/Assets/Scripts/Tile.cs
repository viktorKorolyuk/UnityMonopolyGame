using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Tile
 * Task: Hold values a tile card would have in real Monopoly game
 * Contributors: Viktor Korolyuk, Hongbo Wang
 */

public class Tile : MonoBehaviour {

// Price of the property
  public int originalPrice = 100;

	// Ttype of the property (NOT USED)
  string tileType;
  
// Name of the property
  string propertyName;

// Reference to instance of PlayerController which a Player is using.
  PlayerController owner;



  // Use this for initialization
  void Start() {
    propertyName = gameObject.name; // Set default name
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