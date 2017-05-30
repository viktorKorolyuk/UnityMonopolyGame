using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPopulate : MonoBehaviour {

	public GameObject tile;
	int count = 35;

	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < count; i++) {
			if (i < 9) {
				tile = Instantiate (tile);
				tile.transform.position += new Vector3 (0, 0, -1);
			} else if (i <= 17) {
				tile = Instantiate (tile);
				tile.transform.position += new Vector3 (-1, 0, 0);
			} else if (i > 17 && i <= 26) {
				tile = Instantiate (tile);
				tile.transform.position += new Vector3 (0, 0, 1);
			} else {
				tile = Instantiate (tile);
				tile.transform.position += new Vector3 (1, 0, 0);
			}
		}
	}
}
