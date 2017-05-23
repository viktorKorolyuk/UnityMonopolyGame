using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject /*: MonoBehaviour*/ {

    int square;
    int money;
    List<string> ownedProperty = new List<string>();
    List<string> morgagedProperty = new List<string>();



    PlayerObject() {

    }
    public class property {
        string name;
        int colorGroup;
        int buyPrice;
        int morgagePrice;

        string utilitytype;
        int rent0;  // rent with nothing on it
        int rent1;
        int rent2;
        int rent3;
        int rent4;  //
        int rent5;  // rent with a hotel


        property(string name,int Group, int buyPrice, int morgagePrice,string utilitytype, int rent) {

            this.name = name;
            this.colorGroup = Group;


        }
    }
}
