using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScanner : MonoBehaviour {

	/*
	 * Script to get gameobjects in order of their creation. 
	 * This method should only be used as backup if getting child objects in parent doth not work.
	 */

	//TODO: Make sure bot stays in middle of tile to ensure no overlaps of colliders.


	// Declaring variables
	public float speed = -0.1f;
	Vector3 direction;
	Vector3 offset;
	public List<Tile> tiles = new List<Tile>();

	// Use this for initialization
	void Start () {
		direction = new Vector3 (-speed,0,0);
		offset = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction;
		transform.position += offset; 																		// Move the cube to keep it in the centre of the tiles.
		offset = Vector3.zero;
		if (tiles.Count == 40){
			transform.position = new Vector3 (0,-15,0); 													// Move the cube out of camera view when it has scanned all the tiles, when the list, named "tiles", has 40 locations).
			Destroy(GameObject.FindGameObjectWithTag("Loading"));

		}
	}

	void OnTriggerEnter(Collider obj){
		Tile  objCol = obj.gameObject.GetComponent<Tile> ();
		if (!objCol)
			return;
		if (tiles.Contains (objCol))
			return;
	


		tiles.Add (objCol); 																				// When the cube collides with a tile, add the tile's information to the list named "tiles".
		print (objCol.gameObject.name + " -----" + tiles.Count); 



		if (tiles.Count == 11) {
			direction = new Vector3 (0, 0, speed);															// If the number of locations added to the array, named "tiles", is 11, then change the direction of the cube from going ______ to _____.
			offset = new Vector3 (-tiles [0].gameObject.transform.lossyScale.x / 2, 0, 0);
		} else if (tiles.Count == 21) {
			direction = new Vector3 (speed, 0, 0);															// If the number of locations added to the array, named "tiles", is 21, then change the direction of the cube from going ______ to _____.
			offset = new Vector3 (0, 0, tiles [0].gameObject.transform.lossyScale.x / 2);
		} else if (tiles.Count == 31) {
			direction = new Vector3 (0, 0, -speed);															// If the number of locations added to the array, named "tiles", is 31, then change the direction of the cube from going ______ to _____.
			offset = new Vector3 (tiles [0].gameObject.transform.lossyScale.x / 2, 0, 0);
		} else if (tiles.Count == 40) {
			Debug.LogError ("/bin/bash/ error CB1463: Unexpected symbol '" + Environment.UserName+"'"); 	// If the number of locations added to the array, named "tiles", is 31, then notify the developper.
		}
			
	}
		
	public List<Tile> Tiles {
		get {
			return this.tiles;
		}
		set {
			tiles = value;
		}
	}

}
