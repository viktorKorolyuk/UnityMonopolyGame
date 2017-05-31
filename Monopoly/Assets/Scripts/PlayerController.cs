using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //work with movement!
    int money = 0;
    int getOutOfJailFreeCards = 0;
    int TileIndex = 0;


    // Use this for initialization
    void Start() {
        money = 1500;
    }

    // Money actions
    int getMoney() {
        return money;
    }

    bool enouoghmoney(int sub) {
        if (money - sub > 0) {
            return true;
        } else {
            return false;
        }
    }
    public void payMoney(int pay) {
        money -= pay;
    }
    public void receiveMoney(int received) {
        money += received;
    }

    // Get out of jail free cards
    public void getJailCard() {
        getOutOfJailFreeCards += 1;
    }
    public void playJailCard() {
        getOutOfJailFreeCards -= 1;
    }
    public int getGetOutOfJailCards() {
        return getOutOfJailFreeCards;
    }

    // Movement
    public int getTileIndex() {
        return TileIndex;
    }
	Vector3 pos = Vector3.zero;
    public void Move(int movement, Vector3 newpos) {
        TileIndex += movement;
        TileIndex = TileIndex % 36;
		pos = newpos;
    }
    public void skipTo(int tile, Vector3 newpos) {
        TileIndex = tile;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newpos, 10);
        pos = newpos;
    }

	void Update(){
		pos.y = transform.position.y;
		gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, pos, Time.deltaTime );
	}
}