using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionFind : MonoBehaviour {

    // Reference to all nodes
    private List<Set> forest;

    // Constructor
    public UnionFind() {
        forest = null;
    }

    // Creates a new set and adds it to forest
    public void createSet(string newID) {
        Set newSet = new Set(newID);
        forest.Add(newSet);
    }

    // Finds the parent set which contains set
    public Set findSet(Set set) {
        while (set.getParent() != null) { 
            findSet(set.getParent()); 
        }
        return set;   
    }

    // Combines the two sets if they belong to different sets
    public void union(Set set1, Set set2) {
        Set parentSet1 = findSet(set1);
        Set parentSet2 = findSet(set2);

        // If the parents are not the same, compare ranks and set the lower ranked parent to the higher ranked.
        if (parentSet1 != parentSet2) {
            if (parentSet1.getRank() >= parentSet2.getRank()) {
                parentSet2.setParent(parentSet1);
                // HERE, SET THE LINE ACTIVES BETWEEN SET1 AND SET2
            } else {
                parentSet1.setParent(parentSet2);
                // HERE, SET THE LINE ACTIVES BETWEEN SET1 AND SET2
            }
        }
    }
}
