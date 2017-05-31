using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPopulate : MonoBehaviour {

	/*
	 * TODO: Add a json file-read to generate the gameboard on runtime. This will decrease physical game-prepare time
	 */

	public GameObject tile;
	public int count = 35;
	Transform tr;

	// Use this for initialization
	public bool init () {
		for (int i = 0; i < count; i++) {
			if (i < 9) {
				tile = Instantiate (tile, tr);
				tile.transform.position += new Vector3 (0, 0, -1);
			} else if (i <= 17) {
				tile = Instantiate (tile, tr);
				tile.transform.position += new Vector3 (-1, 0, 0);
			} else if (i > 17 && i <= 26) {
				tile = Instantiate (tile, tr);
				tile.transform.position += new Vector3 (0, 0, 1);
			} else {
				tile = Instantiate (tile, tr);
				tile.transform.position += new Vector3 (1, 0, 0);
			}
		}
		return true;
	}
}
