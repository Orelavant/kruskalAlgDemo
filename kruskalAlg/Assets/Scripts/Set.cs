using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Set class. Contains information of each node and reference to parent sets.
public class Set : object {

    // Rank, parent ref, location of set.
    private int rank;
    private Vector2 location;
    private Set parent;

    // Constructor
    public Set(Vector2 newLocation) {
        rank = 0;
        location = newLocation;
        parent = this;
    }

    public int getRank() {
        return rank;
    }

    public Set getParent() {
        return parent;
    }

    public Vector2 getLocation() {
        return location;
    }

    public void setRank(int newRank) {
        rank = newRank;
    }

    public void setParent(Set newParent) {
        parent = newParent;
    }

    public void setLocation(Vector2 newLocation) {
        location = newLocation;
    }

    public void addRank(int addInt) {
        rank += addInt;
    }
}
