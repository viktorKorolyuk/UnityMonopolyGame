using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public int rent;
	public int location; // Tile number
	public GameObject owner;

	public int houses;
	public int hotels;

	public int locationPrice;
	public int housesPrice;
	public int hotelsPrice;

	// Use this for initialization
	void Start () {

		int rent = locationPrice + housesPrice + hotelsPrice;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
