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

    // Update is called once per frame
    void Update() {

    }
    // money actions
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
    void payMoney(int pay) {
        money -= pay;
    }
    void receiveMoney(int received) {
        money += received;
    }
    // get out of jail free cards

    void getJailCard() {
        getOutOfJailFreeCards += 1;
    }
    void playJailCard() {
        getOutOfJailFreeCards -= 1;
    }
    int getGetOutOfJailCards() {
        return getOutOfJailFreeCards;
    }

    //movement
    int getTileIndex() {
        return TileIndex;
    }
    void Move(int movement, Vector3 newpos) {
        TileIndex += movement;
        TileIndex = TileIndex % 36;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newpos, 10);
    }
    void skipTo(int tile, Vector3 newpos) {
        TileIndex = tile;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newpos, 10);
    }
}