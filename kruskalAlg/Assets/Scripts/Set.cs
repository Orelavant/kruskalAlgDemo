using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour {

    // Reference and rank of set
    private string ID;
    private int rank;
    private Set parent;

    // Constructor
    public Set(string newID) {
        ID = newID;
        rank = 0;
        parent = null;
    }

    public string getID() {
        return ID;
    }

    public int getRank() {
        return rank;
    }

    public Set getParent() {
        return parent;
    }

    public void setID(string newID) {
        ID = newID;
    }

    public void setRank(int newRank) {
        rank = newRank;
    }

    public void setParent(Set newParent) {
        parent = newParent;
    }
}
