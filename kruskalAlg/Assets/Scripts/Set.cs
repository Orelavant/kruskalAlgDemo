using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Set class. Contains information of each node and reference to parent sets.
public class Set : MonoBehaviour {

    // Rank, parent ref, connections of set.
    private int rank;
    private Set parent;

    // Constructor
    public Set() {
        rank = 0;
        parent = this;
    }

    public int getRank() {
        return rank;
    }

    public Set getParent() {
        return parent;
    }

    public void setRank(int newRank) {
        rank = newRank;
    }

    public void setParent(Set newParent) {
        parent = newParent;
    }

    public void addRank(int addInt) {
        rank += addInt;
    }
}
