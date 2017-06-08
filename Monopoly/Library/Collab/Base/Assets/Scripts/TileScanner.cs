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
	public float speed =  -0.1f;
	Vector3 dir;
	Vector3 offset;
	public List<Tile> tiles = new List<Tile>();

	// Use this for initialization
	void Start () {
		dir = new Vector3 (-speed,0,0);
		offset = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += dir;
		transform.position += offset; //offset the scanner to keep in center of doument
		offset = Vector3.zero;
		if (tiles.Count == 40)
			transform.position = new Vector3 (0,-15,0); //Move scanner out of camera view when it has done scanning board.
	}

	void OnTriggerEnter(Collider obj){
		Tile  objCol = obj.gameObject.GetComponent<Tile> ();
		if (!objCol)
			return;
		if (tiles.Contains (objCol))
			return;
		//Append Tile instance to list object
		tiles.Add (objCol);

		switch (tiles.Count) {
		case 11:
			dir = new Vector3 (0, 0, speed);
			offset = new Vector3 (-tiles[0].gameObject.transform.lossyScale.x/2,0,0);
			break;
		case 21:
			dir = new Vector3 (speed, 0, 0);
			offset = new Vector3 (0,0,tiles[0].gameObject.transform.lossyScale.x/2);
			break;
		case 31:
			dir = new Vector3 (0, 0, -speed);
			offset = new Vector3 (tiles[0].gameObject.transform.lossyScale.x/2,0,0);
			break;
		case 40:
			Debug.LogError ("/bin/bash/ error CB1463: Unexpected symbol '" + Environment.UserName+"'"); //Notify developper.
			break;
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
