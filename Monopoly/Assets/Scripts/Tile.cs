﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	string tileType;

	public int rent;
	public int location; // Tile number
	public GameObject owner;

	public int houses; // 1, 2, 3, 4, Hotel

	int locationPrice;

	// Use this for initialization
	void Start () {

		calculateRent ();
			
	}

	void calculateRent () {

	///	int rent = 

	}
}
