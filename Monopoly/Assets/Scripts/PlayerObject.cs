using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour {

    int square;
    float money;

	public void deduct(float price){
		this.money -= price;
	}
	public void move(){
		
	}
}
